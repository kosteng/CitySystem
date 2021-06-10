using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using City;
using DayChangeSystem.Controllers;
using Engine.Mediators;
using Engine.UI;
using UnityEngine;
using Zenject;


public class CityController : IInitializable, IAttachableUi, IDisposable, IUpdatable
{
    private readonly CityDatabase _cityDatabase;
    private readonly CityView _cityView;
    private readonly DayCounterController _dayCounterController;
    private readonly HourController _hourController;
    private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;

    private float _peopleReproduce;
    private float _people;

    public CityController(
        CityDatabase cityDatabase,
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
        RefreshResourcesToView();
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