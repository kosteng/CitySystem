﻿using System;
using Building;
using Building.UI.BuildingInfoBuyPanel;
using UnityEngine;
using Zenject;

public class CityController : IInitializable
{
    private readonly CityDatabase _cityDatabase;
    private readonly CityView _cityView;

    public CityController (CityDatabase cityDatabase, CityView cityView, 
        DayCounterController dayCounterController, BuildingController buildingController, 
        BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter)
    {
        _cityDatabase = cityDatabase;
        _cityView = cityView;
        dayCounterController.OnUpdateDay += NextDay;
        buildingInfoBuyPanelPresenter.OnBuyBuilding += RefreshResourcesToView;
    }
    public void Awake()
    {

    }


    private void NextDay()
    {
        CalculateIncomeResources();
        RefreshResourcesToView();
   //     Debug.Log("Gold " + _cityDatabase.Gold);
    }

    private float _peopleReproduce;
    private float _people;
    private void CalculateIncomeResources()
    {
        _peopleReproduce += _cityDatabase.People * .01f;

        if (_peopleReproduce > 1f)
        {
            var newPeople = (float)Math.Truncate(_peopleReproduce);
            _peopleReproduce -= newPeople;
            _cityDatabase.People += newPeople;
        }

       // Debug.Log(_peopleReproduce);

        _cityDatabase.Food += 50f - _cityDatabase.People - _cityDatabase.Warrior;
        _cityDatabase.Gold += 50f /* _cityDatabase.People */- _cityDatabase.Warrior;
        _cityDatabase.Wood++;
        _cityDatabase.Stone++;
        _cityDatabase.Iron++;
    }

    private void RefreshResourcesToView()
    {
        _cityView.People.text = "People: " + _cityDatabase.People;
        _cityView.Food.text = "Food: " + _cityDatabase.Food;
        _cityView.Gold.text = "Gold: " + _cityDatabase.Gold;
        _cityView.Wood.text = "Wood: " + _cityDatabase.Wood;
        _cityView.Stone.text = "Stone: " + _cityDatabase.Stone;
        _cityView.Iron.text = "Iron: " + _cityDatabase.Iron;
        _cityView.Warrior.text = "Warrior: " + _cityDatabase.Warrior;
    }

    public void Initialize()
    {
        _cityDatabase.Clear();
    }
}
