using System;
using System.Collections.Generic;
using Building.BuildingsData;
using UnityEngine;

namespace Building.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter
    {
        private readonly BuildingUIInfoBuyView _buildingUIInfoBuyView;
        private readonly BottomPanelPresenter _bottomPanelPresenter;
        private readonly BuildingFactory _buildingFactory;
        private readonly AllBuildingsDatabase _allBuildingsDatabase;

        private IBuilding _currentBuild;

        public IBuilding CurrentBuild => _currentBuild;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingUIInfoBuyView buildingUIInfoBuyView,
            BottomPanelPresenter bottomPanelPresenter,
            BuildingFactory buildingFactory,
            AllBuildingsDatabase allBuildingsDatabase)
        {
            _buildingUIInfoBuyView = buildingUIInfoBuyView;
            _bottomPanelPresenter = bottomPanelPresenter;
            _buildingFactory = buildingFactory;
            _allBuildingsDatabase = allBuildingsDatabase;
        }

        public void Awake()
        {
            _bottomPanelPresenter.OnShowBuildingUIInfoBuyView += Show;
            _buildingUIInfoBuyView.OnBuildingClickButton += ShowBuildingData;
            _buildingUIInfoBuyView.OnCloseInfoPanelBuildingClickButton += CloseInfoBuyPanel;
            _buildingUIInfoBuyView.OnBuyBuildingClickButton += BuyBuilding;
            _buildingUIInfoBuyView.gameObject.SetActive(false);
        }

        private void Show()
        {
            _buildingUIInfoBuyView.gameObject.SetActive(!_buildingUIInfoBuyView.gameObject.activeSelf);
        }

        private void CloseInfoBuyPanel()
        {
            _buildingUIInfoBuyView.gameObject.SetActive(false);
        }

        private void ShowBuildingData(EBuildingType buildingType)
        {
            if (buildingType == EBuildingType.House)
            {
                _buildingUIInfoBuyView.SetCostTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.ShowCost());
                _buildingUIInfoBuyView.SetNameTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.Name);
            }
        }

// TO DO придумать способ проверки и оплаты до создания объекта
        private void BuyBuilding(EBuildingType buildingType)
        {
            if (!_allBuildingsDatabase.HouseBuildingDatabase.TryBuyBuilding())
            {
                Debug.Log("Не хватает ресурсов");
                return;
            }

            if (_currentBuild.IsBuy && _currentBuild != null)
            {
                Debug.Log("Куплено уже");
                return;
            }
            
            _currentBuild = _buildingFactory.Create();
            _currentBuild.PayBuilding();
            _currentBuild.SetData();
            OnBuyBuilding?.Invoke();
        }
    }
}