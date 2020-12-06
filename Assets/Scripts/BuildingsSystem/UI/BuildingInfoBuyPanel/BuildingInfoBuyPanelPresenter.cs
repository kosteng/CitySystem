using System;
using System.Collections.Generic;
using System.Linq;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingBuyPanelView _view;
        private readonly AllBuildingsDatabase _allBuildingsDatabase;
        private readonly BuildingButtonBuilder _buildingButtonBuilder;
        private readonly BuildingsStacker _buildingsStacker;
        private readonly PurchaseBuildingsHandler _purchaseBuildingsHandler;
        private readonly CityDatabase _cityDatabase;

        private List<BuildingButtonView> _buttonsList;

        //private IBuilding _currentBuild;
        private BuildingDatabase _currentBuilding;
        public BuildingDatabase CurrentBuild => _currentBuilding;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            AllBuildingsDatabase allBuildingsDatabase,
            BuildingButtonBuilder buildingButtonBuilder,
            BuildingsStacker buildingsStacker,
            PurchaseBuildingsHandler purchaseBuildingsHandler,
            CityDatabase cityDatabase)
        {
            _view = view;
            _allBuildingsDatabase = allBuildingsDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
            _buildingsStacker = buildingsStacker;
            _purchaseBuildingsHandler = purchaseBuildingsHandler;
            _cityDatabase = cityDatabase;
        }
        //TODO рефакторинг зиз
        private void Subscribe()
        {
            _view.OnBuildingClickButton += ShowBuildingData;
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.Subscribe(CloseInfoBuyView, CloseInfoBuyView);
            _buildingsStacker.IsBuildingMontage += PurchaseBuilding;
            
            foreach (var buttons in _buttonsList)
            {
                buttons.Subscribe();
                buttons.OnBuildingClickButton += ShowBuildingData;
            }
            
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            _buttonsList = _buildingButtonBuilder.Create(_view.BuildingButtonsPanel);
            Subscribe();
        }

        public void Show()
        {
            _view.gameObject.SetActive(!_view.gameObject.activeSelf);
        }

        private void CloseInfoBuyView()
        {
            _view.gameObject.SetActive(false);
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
            if (!_purchaseBuildingsHandler.TryPurchaseBuilding(_cityDatabase.Model, _currentBuilding.Resourceses)) 
                return;

            var build = MonoBehaviour.Instantiate(_currentBuilding.View);
            _buildingsStacker.StartPlacingBuilding(build);
        }

        private void PurchaseBuilding()
        {
            _purchaseBuildingsHandler.PurchaseBuilding(_cityDatabase.Model, _currentBuilding.Resourceses);
        }
        
        public void Dispose()
        {
            _view.Unsubscribe();
            _view.OnBuildingClickButton -= ShowBuildingData;
            _view.OnBuyBuildingClickButton -= BuyBuilding;
            _buildingsStacker.IsBuildingMontage -= PurchaseBuilding;
            foreach (var buttons in _buttonsList)
            {
                buttons.Unsubscribe();
                buttons.OnBuildingClickButton -= ShowBuildingData;
            }
        }
    }
}