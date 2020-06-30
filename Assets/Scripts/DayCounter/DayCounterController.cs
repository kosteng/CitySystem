using System;

public class DayCounterController
{
    private float _timer;
    private readonly DayCounterView _dayCounterView;
    private readonly DayCountDatabase _dayCounterDataBase;

    public event Action OnUpdateDay;

    public DayCounterController (DayCountDatabase dayCounterDataBase, DayCounterView dayCounterView)
    {
        _dayCounterDataBase = dayCounterDataBase;
        _dayCounterView = dayCounterView;
    }

    public void Awake()
    {
        _dayCounterDataBase.Clear();
    }

    public void Update(float deltaTime)
    {
        if (_timer > _dayCounterDataBase.HoursCountIsEndedDay)
        {
            _timer = 0f;
            _dayCounterView.DayText.text = "Day: " + ++_dayCounterDataBase.Day;
            OnUpdateDay?.Invoke();
        }
        else _timer += deltaTime;
    }
}
