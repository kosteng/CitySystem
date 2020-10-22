using System;
using Building;
using Engine.Mediators;
using UnityEngine;
using Zenject;

public class DayCounterController : IUpdatable, IInitializable
{
    private float _timer = 0f;
    private readonly DayCounterView _dayCounterView;
    private readonly DayCountDatabase _dayCounterDataBase;

    public event Action OnUpdateDay;

    public DayCounterController (DayCountDatabase dayCounterDataBase, DayCounterView dayCounterView)
    {
        _dayCounterDataBase = dayCounterDataBase;
        _dayCounterView = dayCounterView;
    }
    
    public void Tick()
    {
        _dayCounterView.DayText.text = "Day: " + _dayCounterDataBase.Day;
        if (_timer > _dayCounterDataBase.HoursCountIsEndedDay)
        {
            _timer = 0f;
            _dayCounterView.DayText.text = "Day: " + ++_dayCounterDataBase.Day;
            OnUpdateDay?.Invoke();
        }
        else _timer += Time.deltaTime;
    }

    public void Initialize()
    {
        _dayCounterDataBase.Clear();
    }

    public void Update(float deltaTime)
    {
        _dayCounterView.DayText.text = "Day: " + _dayCounterDataBase.Day;
        if (_timer > _dayCounterDataBase.HoursCountIsEndedDay)
        {
            _timer = 0f;
            _dayCounterView.DayText.text = "Day: " + ++_dayCounterDataBase.Day;
            OnUpdateDay?.Invoke();
        }
        else _timer += Time.deltaTime;
    }
}
