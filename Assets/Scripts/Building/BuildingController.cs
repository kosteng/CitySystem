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
       // _buildingUIInfoBuyView.OnHouseBuildingClickButton += BuyHouse;
       // _buildingUIInfoBuyView.OnSawMillBuildingClickButton += BuySawMill;
       // _buildingUIInfoBuyView.OnMineBuildingClickButton += BuyMine;
        _houseView.gameObject.SetActive(false);
        _sawMillView.gameObject.SetActive(false);
        _mineView.gameObject.SetActive(false);


        GetBuildings();

        foreach (var building in _allBuildingsDatabase.Buildings)
        {
            building.Clear();
        }
    }

    private void BuyHouse()
    {
      //var build = _allBuildingsDatabase.Buildings[(int)EBuildingType.House];
     //   _buildingUIInfoBuyView.SetNameTextInfoPanel(build.Name);
       // _buildingUIInfoBuyView.SetCostTextInfoPanel("Gold: " + 100f + " Wood: " + 75f + " Stone: " + 35f);
        /*
        build.PayBuilding();
        if (!build.IsBuy)
            return;
        _houseView.gameObject.SetActive(true);
        _buildingUIView.HouseBuldingButtonSetActive(false);
        OnBuyBuilding?.Invoke();
        */
    }
    
    private void BuySawMill()
    {
        var build = _allBuildingsDatabase.Buildings[1];
        build.PayBuilding();
        if (!build.IsBuy)
            return;
        _sawMillView.gameObject.SetActive(true);
        _buildingUIInfoBuyView.SawMillBuldingButtonSetActive(false);
        OnBuyBuilding?.Invoke();
    }

    private void BuyMine()
    {
        var build = _allBuildingsDatabase.Buildings[2];
        build.PayBuilding();
        if (!build.IsBuy)
            return;
        _mineView.gameObject.SetActive(true);
        _buildingUIInfoBuyView.MineBuldingButtonSetActive(false);
        OnBuyBuilding?.Invoke();
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
