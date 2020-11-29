using System;
using System.Collections.Generic;
using System.Linq;
using Engine.UI;
using UI.BottomPanel;
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

        private List<BuildingButtonView> _buttonsList;

        //private IBuilding _currentBuild;
        private BuildingDatabase _currentBuilding;
        public BuildingDatabase CurrentBuild => _currentBuilding;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            AllBuildingsDatabase allBuildingsDatabase,
            BuildingButtonBuilder buildingButtonBuilder,
            BuildingsStacker buildingsStacker)
        {
            _view = view;
            _allBuildingsDatabase = allBuildingsDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
            _buildingsStacker = buildingsStacker;
        }

        public void Subscribe()
        {
            _view.OnBuildingClickButton += ShowBuildingData;
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.gameObject.SetActive(false);
            _view.Subscribe(CloseInfoBuyView, CloseInfoBuyView);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            Subscribe();
            _buttonsList = _buildingButtonBuilder.Create(_view.BuildingButtonsPanel);
            foreach (var buttons in _buttonsList)
            {
                buttons.Subscribe();
                buttons.OnBuildingClickButton += ShowBuildingData;
            }
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
            foreach (var building in _allBuildingsDatabase.BuildingsDatabase) //TODO реализовать через linq
            {
                if (building.BuildingType == buildingType)
                {
                    _currentBuilding = building;
                    break;
                }
            }

            _view.SetCost(_currentBuilding.ShowCost());
            _view.SetName(buildingType.ToString());
        }

// TODO придумать способ проверки и оплаты до создания объекта
        private void BuyBuilding(EBuildingType buildingType)
        {
            if (_currentBuilding == null)
                return;
           var build = MonoBehaviour.Instantiate(_currentBuilding.View);
            _buildingsStacker.StartPlacingBuilding(build);
            // // if (!_allBuildingsDatabase.HouseBuildingDatabase.TryBuyBuilding())
            // // {
            // //     Debug.Log("Не хватает ресурсов");
            // //     return;
            // // }
            //
            // if (_currentBuild.IsBuy && _currentBuild != null)
            // {
            //     Debug.Log("Куплено уже");
            //     return;
            // }
            //
            // //  _currentBuild = _buildingFactory.Create();
            // _currentBuild.PayBuilding();
            // _currentBuild.SetData();
            // OnBuyBuilding?.Invoke();
        }

        public void Dispose()
        {
            _view.Unsubscribe();
            _view.OnBuildingClickButton -= ShowBuildingData;

            foreach (var buttons in _buttonsList)
            {
                buttons.Unsubscribe();
                buttons.OnBuildingClickButton -= ShowBuildingData;
            }
        }
    }
}