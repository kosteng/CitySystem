using System;
using System.Collections.Generic;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using UnityEngine;
using Zenject;

public class BuildingController : IInitializable, IDisposable
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly DayCounterController _dayCounterController;
    private readonly HourController _hourController;

    private List<IBuilding> _buildings = new List<IBuilding>();

    public BuildingController(
        DayCounterController dayCounterController,
        HourController hourController)
    {
        _dayCounterController = dayCounterController;
        _hourController = hourController;
    }

    private void NextDayChanged()
    {
    }

    public void AddBuildings(IBuilding building)
    {
        building.Subscribe();
        building.OnBuildingClickHandler += OpenBuildingWindow;
        _buildings.Add(building);
    }

// заглушка на отписку, добавил метод чтобы не забыть
    private void DestroyBuilding(IBuilding building)
    {
        building.OnBuildingClickHandler -= OpenBuildingWindow;
    }

    private void OpenBuildingWindow(ABuildingView buildingView)
    {
        Debug.Log("Delegate");
    }

    private void NextHour()
    {
        foreach (var building in _buildings)
        {
            building.Income();
            building.Expense();
        }
    }

    public void Initialize()
    {
        _dayCounterController.OnDayChanged += NextDayChanged;
        _hourController.OnHourChanged += NextHour;
    }

    public void Dispose()
    {
        _dayCounterController.OnDayChanged -= NextDayChanged;
        _hourController.OnHourChanged -= NextHour;
    }
}