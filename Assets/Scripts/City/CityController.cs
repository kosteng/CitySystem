using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using Engine.Mediators;
using Engine.UI;
using System;
using UnityEngine;
using Zenject;

namespace City
{
    public class CityController : IInitializable, IAttachableUi, IDisposable, IUpdatable
    {
        private readonly CityView _cityView;
        private readonly DayCounterController _dayCounterController;
        private readonly HourController _hourController;
        private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;

        private readonly CityModel _cityModel;
        public ResourcesModel CityResourcesModel => _cityModel.ResourcesModel;
        public CityModel CityModel => _cityModel;
        
        public CityController(
            CityView cityView,
            DayCounterController dayCounterController,
            HourController hourController,
            BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter,
            CityModel cityModel)
        {
            _cityView = cityView;
            _dayCounterController = dayCounterController;
            _hourController = hourController;
            _buildingInfoBuyPanelPresenter = buildingInfoBuyPanelPresenter;
            _cityModel = cityModel;
        }

        private void NextDayChanged()
        {
            RefreshResourcesToView();
        }

        private void RefreshResourcesToView()
        {
            _cityView.Food.text = "Food: " + _cityModel.ResourcesModel.Food;
            _cityView.Gold.text = "Gold: " + _cityModel.ResourcesModel.Gold;
            _cityView.Wood.text = "Wood: " + _cityModel.ResourcesModel.Wood;
            _cityView.Stone.text = "Stone: " + _cityModel.ResourcesModel.Stone; 
            _cityView.Iron.text = "Iron: " + _cityModel.ResourcesModel.Iron;
        }

        public void Initialize()
        {
            RefreshResourcesToView();
            _dayCounterController.OnDayChanged += NextDayChanged;
            _buildingInfoBuyPanelPresenter.OnBuyBuilding += RefreshResourcesToView;
            _hourController.OnHourChanged += RefreshResourcesToView;
        }

        public void Attach(Transform parent)
        {
            _cityView.Attach(parent);
        }

        public void Dispose()
        {
            _dayCounterController.OnDayChanged -= NextDayChanged;
            _buildingInfoBuyPanelPresenter.OnBuyBuilding -= RefreshResourcesToView;
            _hourController.OnHourChanged -= RefreshResourcesToView;
        }

//todo убрать обновление каждый кадр после тестов
        public void Update(float deltaTime)
        {
            RefreshResourcesToView();
        }
    }
}