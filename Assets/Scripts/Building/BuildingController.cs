using System;
using System.Collections.Generic;

public class BuildingController 
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly DayCounterController _dayCounterController;
    private readonly List<IBuildingIncome> _buildingIncomes = new List<IBuildingIncome>();
    private readonly BuildingUIInfoBuyView _buildingUIInfoBuyView;
    private readonly BuildingView _houseView;
    private readonly BuildingView _sawMillView;
    private readonly BuildingView _mineView;
    public event Action OnBuyBuilding;

    public BuildingController(
        AllBuildingsDatabase allBuildingsDatabase, 
        DayCounterController dayCounterController,
        BuildingUIInfoBuyView buildingUIView, 
        BuildingView houseView, 
        BuildingView sawMillView, 
        BuildingView mineView)
    {
        _allBuildingsDatabase = allBuildingsDatabase;
        _dayCounterController = dayCounterController;
        _buildingUIInfoBuyView = buildingUIView;
        _houseView = houseView;
        _sawMillView = sawMillView;
        _mineView = mineView;
    }

    public void Awake()
    {
        _dayCounterController.OnUpdateDay += NextDay;
        _houseView.gameObject.SetActive(false);
        _sawMillView.gameObject.SetActive(false);
        _mineView.gameObject.SetActive(false);


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
        foreach (var building in _buildingIncomes)
        {
            building.Income();
        }
    }
}
