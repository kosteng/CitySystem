using System;
using DayChangeSystem.Databases;
using DayChangeSystem.Interfaces;
using UnityEngine;

namespace Engine.Mediators
{
    public class HourController : IUpdatable
    {
        private float _timer = 0.0f;
        private readonly DaySettingsDatabase _daySettingsDatabase;
        private readonly IDayModel _dayModel;
        public event Action OnHourChanged;
        public HourController(DaySettingsDatabase daySettingsDatabase, IDayModel dayModel)
        {
            _daySettingsDatabase = daySettingsDatabase;
            _dayModel = dayModel;
        }

        public void Update(float deltaTime)
        {
            if (_timer >= _daySettingsDatabase.HourLength)
            {
                _timer = 0f;
                _dayModel.Hours++;
                OnHourChanged?.Invoke();
            }
            else _timer += deltaTime;
        }
    }
}
