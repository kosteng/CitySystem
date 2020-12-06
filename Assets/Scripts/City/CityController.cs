using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using City;
using DayChangeSystem.Controllers;
using Engine.UI;
using UnityEngine;
using Zenject;

public class CityController : IInitializable, IAttachableUi, IDisposable
{
    private readonly CityDatabase _cityDatabase;
    private readonly CityView _cityView;
    private readonly DayCounterController _dayCounterController;
    private readonly HourController _hourController;
    private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;

    private float _peopleReproduce;
    private float _people;
    public CityController (CityDatabase cityDatabase, 
        CityView cityView, 
        DayCounterController dayCounterController,
        HourController hourController, 
        BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter)
    {
        _cityDatabase = cityDatabase;
        _cityView = cityView;
        _dayCounterController = dayCounterController;
        _hourController = hourController;
        _buildingInfoBuyPanelPresenter = buildingInfoBuyPanelPresenter;
    }

    private void NextDayChanged()
    {
        CalculateIncomeResources();
        RefreshResourcesToView();
   //     Debug.Log("Gold " + _cityDatabase.Gold);
    }

    private void CalculateIncomeResources()
    {
        _peopleReproduce += _cityDatabase.People * .01f;

        if (_peopleReproduce > 1f)
        {
            var newPeople = (float)Math.Truncate(_peopleReproduce);
            _peopleReproduce -= newPeople;
            _cityDatabase.People += newPeople;
        }

        _cityDatabase.Food += 50f - _cityDatabase.People - _cityDatabase.Warrior;
        _cityDatabase.Gold += 50f /* _cityDatabase.People */- _cityDatabase.Warrior;
        _cityDatabase.Wood++;
        _cityDatabase.Stone++;
        _cityDatabase.Iron++;
    }

    private void RefreshResourcesToView()
    {
        _cityView.People.text = "People: " + _cityDatabase.Model.People;
        _cityView.Food.text = "Food: " + _cityDatabase.Model.Food;
        _cityView.Gold.text = "Gold: " + _cityDatabase.Model.Gold;
        _cityView.Wood.text = "Wood: " + _cityDatabase.Model.Wood;
        _cityView.Stone.text = "Stone: " + _cityDatabase.Model.Stone;
        _cityView.Iron.text = "Iron: " + _cityDatabase.Model.Iron;
        _cityView.Warrior.text = "Warrior: " + _cityDatabase.Model.Warrior;
    }

    public void Initialize()
    {
        RefreshResourcesToView();
        _dayCounterController.OnDayChanged += NextDayChanged;
        _buildingInfoBuyPanelPresenter.OnBuyBuilding += RefreshResourcesToView;
        _hourController.OnHourChanged += RefreshResourcesToView;
//        _cityDatabase.Clear();
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
}
