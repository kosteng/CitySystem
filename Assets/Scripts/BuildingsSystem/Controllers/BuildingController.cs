using BuildingsSystem.Databases;
using BuildingsSystem.Interfaces;
using System;
using System.Collections.Generic;
using DayChangeSystem.Controllers;
using UI.BottomPanel;
using Zenject;

namespace BuildingsSystem.Controllers
{
    public class BuildingController : IInitializable, IDisposable, IBuildingController
    {
        private readonly BuildingsModelDatabase _buildingsModelDatabase;
        private readonly DayCounterController _dayCounterController;
        private readonly HourController _hourController;
        private readonly BuildingWindowInfoPresenter _buildingWindowInfoPresenter;

        private List<IBuilding> _buildings = new List<IBuilding>();

        public BuildingController(
            DayCounterController dayCounterController,
            HourController hourController,
            BuildingWindowInfoPresenter buildingWindowInfoPresenter)
        {
            _dayCounterController = dayCounterController;
            _hourController = hourController;
            _buildingWindowInfoPresenter = buildingWindowInfoPresenter;
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

        private void OpenBuildingWindow(ABuildingModel buildingView)
        {
            _buildingWindowInfoPresenter.Show(buildingView);
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
}