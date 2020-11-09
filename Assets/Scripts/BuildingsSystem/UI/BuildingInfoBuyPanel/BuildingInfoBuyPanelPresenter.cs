using System;
using Engine.UI;
using UI.BottomPanel;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingBuyPanelView _view;
        private readonly BottomPanelPresenter _bottomPanelPresenter;
        private readonly AllBuildingsDatabase _allBuildingsDatabase;

        private IBuilding _currentBuild;

        public IBuilding CurrentBuild => _currentBuild;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            BottomPanelPresenter bottomPanelPresenter,
            AllBuildingsDatabase allBuildingsDatabase)
        {
            _view = view;
            _bottomPanelPresenter = bottomPanelPresenter;
            _allBuildingsDatabase = allBuildingsDatabase;

        }

        public void Subscribe()
        {
            _bottomPanelPresenter.OnShowBuildingUIInfoBuyView += Show;
            _view.OnBuildingClickButton += ShowBuildingData;
            _view.OnCloseInfoPanelBuildingClickButton += CloseInfoBuyView;
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            Subscribe();
        }
        
        private void Show()
        {
            _view.gameObject.SetActive(!_view.gameObject.activeSelf);
        }

        private void CloseInfoBuyView()
        {
            _view.gameObject.SetActive(false);
        }

        private void ShowBuildingData(EBuildingType buildingType)
        {
            if (buildingType == EBuildingType.House)
            {
                _view.SetCostTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.ShowCost());
                _view.SetNameTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.Name);
            }
        }

// TODO придумать способ проверки и оплаты до создания объекта
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

          //  _currentBuild = _buildingFactory.Create();
            _currentBuild.PayBuilding();
            _currentBuild.SetData();
            OnBuyBuilding?.Invoke();
        }

        public void Dispose()
        {
            _bottomPanelPresenter.OnShowBuildingUIInfoBuyView -= Show;
            _view.OnBuildingClickButton -= ShowBuildingData;
            _view.OnCloseInfoPanelBuildingClickButton -= CloseInfoBuyView;
            _view.OnBuyBuildingClickButton -= BuyBuilding;
        }
    }
}