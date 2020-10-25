﻿using System;
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
        
        public event Action OnDayChanged;

        public DayCounterController (DaySettingsDatabase daySettingsDatabase, 
            DayCounterView dayCounterView, 
            IDayModel dayModel,
            HourController hourController)
        {
            _daySettingsDatabase = daySettingsDatabase;
            _dayCounterView = dayCounterView;
            _dayModel = dayModel;
            _hourController = hourController;
            
            _hourController.OnHourChanged += TryDayChange;
            _dayCounterView.DayText.text = "Day: " + _dayModel.Days;
        }


        private void TryDayChange()
        {
            if(_dayModel.Hours <= _daySettingsDatabase.DayLength)
                return;
            _dayModel.Days++;
            _dayModel.Hours = 0;
            OnDayChanged?.Invoke();
            RefreshView();
        }

        private void RefreshView()
        {
            _dayCounterView.DayText.text = "Day: " + _dayModel.Days;
        }

        public void Dispose()
        {
            _hourController.OnHourChanged -= TryDayChange;
        }
    }
}
