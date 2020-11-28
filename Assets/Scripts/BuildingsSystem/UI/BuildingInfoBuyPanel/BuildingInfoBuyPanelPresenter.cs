using System;
using System.Collections.Generic;
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
        private List<BuildingButtonView> _buttonsList;
        private IBuilding _currentBuild;

        public IBuilding CurrentBuild => _currentBuild;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            AllBuildingsDatabase allBuildingsDatabase,
            BuildingButtonBuilder buildingButtonBuilder)
        {
            _view = view;
            _allBuildingsDatabase = allBuildingsDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
        }

        public void Subscribe()
        {
            _view.OnBuildingClickButton += ShowBuildingData;
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.gameObject.SetActive(false);
            _view.Subscribe(CloseInfoBuyView,CloseInfoBuyView);
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
            if (buildingType == EBuildingType.House)
            {
                _view.SetCost(_allBuildingsDatabase.BuildingsDatabase[0].ShowCost());
                _view.SetName(buildingType.ToString());
            }

            if (buildingType == EBuildingType.Mine)
            {
                _view.SetCost(_allBuildingsDatabase.BuildingsDatabase[1].ShowCost());
                _view.SetName(buildingType.ToString());
            }

            if (buildingType == EBuildingType.SawMill)
            {
                _view.SetCost(_allBuildingsDatabase.BuildingsDatabase[2].ShowCost());
                _view.SetName(buildingType.ToString());
            }
        }

// TODO придумать способ проверки и оплаты до создания объекта
        private void BuyBuilding(EBuildingType buildingType)
        {
            // if (!_allBuildingsDatabase.HouseBuildingDatabase.TryBuyBuilding())
            // {
            //     Debug.Log("Не хватает ресурсов");
            //     return;
            // }

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