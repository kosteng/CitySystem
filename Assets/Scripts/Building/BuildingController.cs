using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController 
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly List<IBuildingIncome> _buildingIncomes = new List<IBuildingIncome>();
    private readonly BuildingUIView _buildingUIView;
    private readonly BuildingView _houseView;
    private readonly BuildingView _sawMillView;
    private readonly BuildingView _mineView;

    public BuildingController(AllBuildingsDatabase allBuildingsDatabase, DayCounterController dayCounterController,
        BuildingUIView buildingUIView, BuildingView houseView, BuildingView sawMillView, BuildingView mineView)
    {
        _allBuildingsDatabase = allBuildingsDatabase;
        dayCounterController.OnUpdateDay += NextDay;
        _buildingUIView = buildingUIView;
        _houseView = houseView;
        _sawMillView = sawMillView;
        _mineView = mineView;
        _buildingUIView.OnHouseBildingClickButton += BuyHouse;
        _buildingUIView.OnSawMillBildingClickButton += BuySawMill;
        _buildingUIView.OnMineBildingClickButton += BuyMine;
        _houseView.gameObject.SetActive(false);
        _sawMillView.gameObject.SetActive(false);
        _mineView.gameObject.SetActive(false);
        GetBuildings();
    }

    private void BuyHouse()
    {
        var build = _allBuildingsDatabase.Buildings[0];
        build.PayBuilding();
        if (build.IsBuy)
        {
            _houseView.gameObject.SetActive(true);
            _buildingUIView.HouseBuldingButtonSetActive(false);
        }
    }
    
    private void BuySawMill()
    {
        var build = _allBuildingsDatabase.Buildings[1];
        build.PayBuilding();
        if (build.IsBuy)
        {
            _sawMillView.gameObject.SetActive(true);
            _buildingUIView.SawMillBuldingButtonSetActive(false);
        }
    }

    private void BuyMine()
    {
        var build = _allBuildingsDatabase.Buildings[2];
        build.PayBuilding();
        if (build.IsBuy)
        {
            _mineView.gameObject.SetActive(true);
            _buildingUIView.MineBuldingButtonSetActive(false);
        }
    }
    private void GetBuildings()
    {
        foreach (var building in _allBuildingsDatabase.Buildings)
        {
            _buildingIncomes.Add(building);
        }
    }

    private void NextDay()
    {
        foreach (var building in _buildingIncomes)
        {
            building.Income();
        }
    }
}
