using System.Collections.Generic;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem.Controllers;
using Zenject;

public class BuildingController : IInitializable
{
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly DayCounterController _dayCounterController;
    private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;
    private readonly HouseBuildingView _houseBuildingView;

    private List<IBuilding> _buildings = new List<IBuilding>();

    public BuildingController(
        DayCounterController dayCounterController,
        BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter,
        HouseBuildingView houseBuildingView)
    {
        _dayCounterController = dayCounterController;
        _buildingInfoBuyPanelPresenter = buildingInfoBuyPanelPresenter;
        _houseBuildingView = houseBuildingView;
    }

    public void Awake()
    {
        _dayCounterController.OnDayChanged += NextDayChanged;
        _buildingInfoBuyPanelPresenter.OnBuyBuilding += SetActiveHouse;
    }

    private void SetActiveHouse()
    {
        if (_buildingInfoBuyPanelPresenter == null)
            return;
        var build = _buildingInfoBuyPanelPresenter.CurrentBuild;
        build.SetActive(true);
        _buildings.Add(build);
    }
    //  private void GetBuildings()
    //  {
    //    foreach (var building in _allBuildingsDatabase.Buildings.Values)
    //    {
    //   _buildingIncomes.Add(building);
    //     }
    // }

    private void NextDayChanged()
    {
    }

    public void Initialize()
    {
        _dayCounterController.OnDayChanged += NextDayChanged;
        _buildingInfoBuyPanelPresenter.OnBuyBuilding += SetActiveHouse;
    }
}