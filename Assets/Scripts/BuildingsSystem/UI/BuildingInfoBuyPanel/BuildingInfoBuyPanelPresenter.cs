using System;
using System.Collections.Generic;
using System.Linq;
using BuildingsSystem.Controllers;
using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingBuyPanelView _view;
        private readonly AllBuildingsDatabase _allBuildingsDatabase;
        private readonly IBuildingButtonBuilder _buildingButtonBuilder;
        private readonly IBuildingsStacker _buildingsStacker;
        private readonly PurchaseBuildingsHandler _purchaseBuildingsHandler;
        private readonly IBuildingFactory _buildingFactory;
        private readonly IBuildingController _buildingController;
        private readonly CityModel _cityModel;

        private List<BuildingButtonView> _buttonsList;

        private BuildingDatabase _currentBuilding;
        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            AllBuildingsDatabase allBuildingsDatabase,
            IBuildingButtonBuilder buildingButtonBuilder,
            IBuildingsStacker buildingsStacker,
            PurchaseBuildingsHandler purchaseBuildingsHandler,
            IBuildingFactory buildingFactory,
            IBuildingController buildingController,
            CityModel cityModel)
        {
            _view = view;
            _allBuildingsDatabase = allBuildingsDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
            _buildingsStacker = buildingsStacker;
            _purchaseBuildingsHandler = purchaseBuildingsHandler;
            _buildingFactory = buildingFactory;
            _buildingController = buildingController;
            _cityModel = cityModel;
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
            foreach (var building in _allBuildingsDatabase.BuildingsDatabase.Where(building =>
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
            if (!_purchaseBuildingsHandler.TryPurchaseBuilding(_cityModel, _currentBuilding.CostResourcesData))
                return;

            var buildingObject = _buildingFactory.Create(_currentBuilding.View);
            _buildingsStacker.StartPlacingBuilding(buildingObject);
        }

        private void PurchaseBuilding(ABuildingView montageBuilding)
        {
            _purchaseBuildingsHandler.PurchaseBuilding(_cityModel, _currentBuilding.CostResourcesData);

           _buildingController.AddBuildings(_buildingFactory.Create(_currentBuilding, _cityModel));
            OnBuyBuilding?.Invoke();
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