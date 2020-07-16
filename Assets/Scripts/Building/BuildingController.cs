using System;
using System.Collections.Generic;
using UnityEngine;
public class BuildingController 
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly DayCounterController _dayCounterController;
    private readonly List<IBuildingIncome> _buildingIncomes = new List<IBuildingIncome>();
    private readonly BuildingUIInfoBuyView _buildingUIInfoBuyView;
    private readonly BuidingsStorageHandler _buidingsStorageHandler;

    public event Action OnBuyBuilding;

    public BuildingController(
        AllBuildingsDatabase allBuildingsDatabase, 
        DayCounterController dayCounterController,
        BuildingUIInfoBuyView buildingUIView,
        BuidingsStorageHandler buidingsStorageHandler)
    {
        _allBuildingsDatabase = allBuildingsDatabase;
        _dayCounterController = dayCounterController;
        _buildingUIInfoBuyView = buildingUIView;
        _buidingsStorageHandler = buidingsStorageHandler;
    }

    public void Awake()
    {
        _dayCounterController.OnUpdateDay += NextDay;
        _buidingsStorageHandler.Awake();
        GetBuildings();
        foreach (var building in _allBuildingsDatabase.Buildings.Values)
        {
            building.Clear();
        }
    }

    private void GetBuildings()
    {
        foreach (var building in _allBuildingsDatabase.Buildings.Values)
        {
            _buildingIncomes.Add(building);
        }
    }

    private void NextDay()
    {
        /*   foreach (var building in _buildingIncomes)
           {
               building.Income();
           }
           */
        Debug.Log("Count " + _buidingsStorageHandler.HouseBuildings.Count);
        foreach (var building in _buidingsStorageHandler.HouseBuildings)
        {
            building.Income();
        }
    }
}
