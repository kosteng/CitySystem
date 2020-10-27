using System;
using DayChangeSystem.Databases;
using DayChangeSystem.Interfaces;
using Engine.Mediators;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DayChangeSystem.Controllers
{
    public class DayCounterController : IDisposable 
    {
        private readonly DayCounterView _dayCounterView;
        private readonly DaySettingsDatabase _daySettingsDatabase;
        private readonly HourController _hourController;
        private readonly IDayModel _dayModel;
        private ESeasonsType _currentSeason;
        private int _seasonsCounter;
        public event Action OnDayChanged;

        public ESeasonsType CurrentSeason => _currentSeason;

        public DayCounterController (DaySettingsDatabase daySettingsDatabase, 
            DayCounterView dayCounterView, 
            IDayModel dayModel,
            HourController hourController)
        {
            _daySettingsDatabase = daySettingsDatabase;
            _dayCounterView = dayCounterView;
            _dayModel = dayModel;
            _hourController = hourController;

            Start();
        }

        private void Start()
        {
            _hourController.OnHourChanged += TryDayChange;
            _dayCounterView.DayText.text = "Day: " + _dayModel.Days;
            _seasonsCounter = 1;
            _currentSeason = (ESeasonsType) _seasonsCounter;
            _dayCounterView.SeasonText.text = _currentSeason.ToString();
        }


        private void TryDayChange()
        {
            if(_dayModel.Hours < _daySettingsDatabase.DayLength)
                return;
            _dayModel.Days++;
            _dayModel.Hours = 0;
            OnDayChanged?.Invoke();
            TryChangeSeason();
            RefreshView();
        }
        private bool _isReadyChangeSeason = false;
        private void TryChangeSeason()
        {
            if (_isReadyChangeSeason)
            {
                _currentSeason = (ESeasonsType) _seasonsCounter;
                _isReadyChangeSeason = false;
                return;
            }

            if (_dayModel.Days % _daySettingsDatabase.DaysInSeason == 0)
            {
                _seasonsCounter++;
                _isReadyChangeSeason = true;
            }

            if (_seasonsCounter > 4)
                _seasonsCounter = 1;
        }

        private void RefreshView()
        {
            _dayCounterView.DayText.text = "Day: " + _dayModel.Days;
            _dayCounterView.SeasonText.text = _currentSeason.ToString();
        }

        public void Dispose()
        {
            _hourController.OnHourChanged -= TryDayChange;
        }
    }
}
