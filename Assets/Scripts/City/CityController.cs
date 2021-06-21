﻿using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using Engine.Mediators;
using Engine.UI;
using Items.ResourceItems;
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
            foreach (var item in _cityModel.ResourceItemsData)
            {
                switch (item.ResourceItemType)
                {
                    case EResourceItemType.None:
                        break;
                    case EResourceItemType.Gold:
                        _cityView.Gold.text = $"Gold: {item.Amount}";
                        break;
                    case EResourceItemType.Food:
                        _cityView.Food.text = $"Food: {item.Amount}";
                        break;
                    case EResourceItemType.Log:
                        _cityView.Log.text = $"Log: {item.Amount}";
                        break;
                    case EResourceItemType.Stone:
                        _cityView.Stone.text = $"Stone: {item.Amount}";
                        break;
                    case EResourceItemType.Iron:
                        _cityView.Iron.text = $"Iron: {item.Amount}";
                        break;
                    case EResourceItemType.Stick:
                        break;
                    case EResourceItemType.Straw:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
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