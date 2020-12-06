using System;
using System.Collections.Generic;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using Zenject;

public class BuildingController : IInitializable, IDisposable
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly DayCounterController _dayCounterController;
    private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;
    private readonly HourController _hourController;

    private List<IBuilding> _buildings = new List<IBuilding>();

    public BuildingController(
        DayCounterController dayCounterController,
        BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter,
        HourController hourController)
    {
        _dayCounterController = dayCounterController;
        _buildingInfoBuyPanelPresenter = buildingInfoBuyPanelPresenter;
        _hourController = hourController;
    }

    private void NextDayChanged()
    {
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
        _buildings = _buildingInfoBuyPanelPresenter.Buildings;
        _dayCounterController.OnDayChanged += NextDayChanged;
        _hourController.OnHourChanged += NextHour;
        
    }

    public void Dispose()
    {
        _dayCounterController.OnDayChanged -= NextDayChanged;
        _hourController.OnHourChanged -= NextHour;
    }
}