using System;
using Building;
using UnityEngine;
using Zenject;

public class DayCounterController : IUpdatable, ITickable, IInitializable
{
    private float _timer;
    private readonly DayCounterView _dayCounterView;
    private readonly DayCountDatabase _dayCounterDataBase;
    private readonly HouseBuildingView _house;

    public event Action OnUpdateDay;

    public DayCounterController (DayCountDatabase dayCounterDataBase, DayCounterView dayCounterView, HouseBuildingView house)
    {
        _dayCounterDataBase = dayCounterDataBase;
        _dayCounterView = dayCounterView;
        _house = house;
    }

    public void Awake()
    {
        _dayCounterDataBase.Clear();
    }

    public void Update(float deltaTime)
    { 
        _dayCounterView.DayText.text = "Day: " + ++_dayCounterDataBase.Day;
        if (_timer > _dayCounterDataBase.HoursCountIsEndedDay)
        {
            _timer = 0f;
            _dayCounterView.DayText.text = "Day: " + ++_dayCounterDataBase.Day;
         //   OnUpdateDay?.Invoke();
        }
        else _timer += deltaTime;
    }

    public void Tick()
    {

        _dayCounterView.DayText.text = "" + ++_dayCounterDataBase.Day;
    }

    public void Initialize()
    {
        _house.Create();
    }
}
