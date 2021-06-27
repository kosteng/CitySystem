using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using Engine.Mediators;
using Engine.UI;
using InputControls;
using Items.ResourceItems;
using System;
using UnityEngine;
using Zenject;

namespace City
{
    public interface ICityController
    {
        IResourcesStorage ResourcesStorage { get; }
    }

    public class CityController : ICityController, IInitializable, IAttachableUi, IDisposable, IUpdatable
    {
        private readonly CityView _cityView;
        private readonly DayCounterController _dayCounterController;
        private readonly HourController _hourController;
        private readonly ResourceItemsDatabase _resourceItemsDatabase;

        private readonly IResourcesStorage _resourcesStorage;
        private readonly IPlayerInputControls _playerInputControls;

        public IResourcesStorage ResourcesStorage => _resourcesStorage;

        public CityController(
            CityView cityView,
            DayCounterController dayCounterController,
            HourController hourController,
            ResourceItemsDatabase resourceItemsDatabase,
            IPlayerInputControls playerInputControls)
        {
            _cityView = cityView;
            _dayCounterController = dayCounterController;
            _hourController = hourController;
            _resourcesStorage = new ResourcesStorage(resourceItemsDatabase); // todo фабрика
            _playerInputControls = playerInputControls;
            _resourcesStorage.OnChanced += RefreshResourcesToView;
        }

        private void NextDayChanged()
        {
            RefreshResourcesToView();
        }

        private void RefreshResourcesToView()
        {
            _cityView.Warrior.text = string.Empty;
            foreach (var item in _resourcesStorage.ResourceItemsData)
            {
                _cityView.Warrior.text += $"{item.ResourceItemType.ToString()} {item.Amount} \n";
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
            _resourcesStorage.OnChanced += RefreshResourcesToView;
            _dayCounterController.OnDayChanged += NextDayChanged;
            _hourController.OnHourChanged += RefreshResourcesToView;
        }

        public void Attach(Transform parent)
        {
            _cityView.Attach(parent);
        }

        public void Dispose()
        {
            _dayCounterController.OnDayChanged -= NextDayChanged;
            _hourController.OnHourChanged -= RefreshResourcesToView;
            _resourcesStorage.OnChanced -= RefreshResourcesToView;
        }
        
        public void Update(float deltaTime)
        {
            //todo грязный дебаг 
            _playerInputControls.ShowHideCityResourcesPanel(_cityView.DebugPanel);

        }
    }
}