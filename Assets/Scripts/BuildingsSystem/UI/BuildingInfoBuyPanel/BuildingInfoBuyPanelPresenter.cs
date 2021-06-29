using System;
using System.Collections.Generic;
using System.Linq;
using BuildingsSystem.Controllers;
using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using Engine.UI;
using Items.ResourceItems;
using Units.Controllers;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingBuyPanelView _view;
        private readonly BuildingsModelDatabase _buildingsModelDatabase;
        private readonly IBuildingButtonBuilder _buildingButtonBuilder;
        private readonly IBuildingsStacker _buildingsStacker;
        private readonly PurchaseBuildingsHandler _purchaseBuildingsHandler;
        private readonly IBuildingFactory _buildingFactory;
        private readonly IBuildingController _buildingController;
        private readonly IResourcesStorage _resourcesStorage;
        private ABuildingView _prefabBuilding;
        private List<BuildingButtonView> _buttonsList;

        private BuildingDatabase _currentBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            BuildingsModelDatabase buildingsModelDatabase,
            IBuildingButtonBuilder buildingButtonBuilder,
            IBuildingsStacker buildingsStacker,
            PurchaseBuildingsHandler purchaseBuildingsHandler,
            IBuildingFactory buildingFactory,
            IBuildingController buildingController,
            CharacterMovementController characterMovementController)
        {
            _view = view;
            _buildingsModelDatabase = buildingsModelDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
            _buildingsStacker = buildingsStacker;
            _purchaseBuildingsHandler = purchaseBuildingsHandler;
            _buildingFactory = buildingFactory;
            _buildingController = buildingController;

            _resourcesStorage = characterMovementController.CharacterModel.ResourcesStorage;
        }

        public void Initialize()
        {
            _buttonsList = _buildingButtonBuilder.Create(_view.BuildingButtonsPanel);
            Subscribe();
        }

        private void CloseInfoBuyView()
        {
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        //TODO рефакторинг зиз
        private void Subscribe()
        {
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.Subscribe(CloseInfoBuyView, CloseInfoBuyView);
            _buildingsStacker.OnBuildingMontage += PurchaseBuilding;

            foreach (var buttons in _buttonsList)
            {
                buttons.Subscribe();
                buttons.OnBuildingClickButton += ShowBuildingData;
            }

            _view.gameObject.SetActive(false);
        }

        public void Show()
        {
            _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            _currentBuilding = null;
        }

        private void ShowBuildingData(EBuildingType buildingType)
        {
            foreach (var building in _buildingsModelDatabase.BuildingsDatabase.Where(building =>
                building.BuildingType == buildingType))
            {
                _currentBuilding = building;
                break;
            }

            _view.SetCost(_currentBuilding.ShowCost());
            _view.SetName(buildingType.ToString());
        }

        private void BuyBuilding(EBuildingType buildingType)
        {
            if (_currentBuilding == null)
                return;
            if (!_purchaseBuildingsHandler.TryPurchaseBuilding(_resourcesStorage, _currentBuilding.CostResourcesData))
                return;

            _prefabBuilding = _buildingFactory.Create(_currentBuilding.View);
            _buildingsStacker.StartPlacingBuilding(_prefabBuilding);
        }

        private void PurchaseBuilding(ABuildingView montageBuilding)
        {
            _purchaseBuildingsHandler.PurchaseBuilding(_resourcesStorage, _currentBuilding.CostResourcesData);
            _buildingController.AddBuildings(_buildingFactory.Create(_prefabBuilding, _currentBuilding, _resourcesStorage));
        }

        public void Dispose()
        {
            _view.Unsubscribe();
            _view.OnBuyBuildingClickButton -= BuyBuilding;
            _buildingsStacker.OnBuildingMontage -= PurchaseBuilding;

            foreach (var buttons in _buttonsList)
            {
                buttons.Unsubscribe();
                buttons.OnBuildingClickButton -= ShowBuildingData;
            }
        }
    }
}