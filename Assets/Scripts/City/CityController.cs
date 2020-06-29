public class CityController 
{
    private readonly CityDatabase _cityDatabase;
    private readonly CityView _cityView;
    private readonly DayCounterController _dayCounterController;

    public CityController (CityDatabase cityDatabase, CityView cityView, DayCounterController dayCounterController)
    {
        _cityDatabase = cityDatabase;
        _cityView = cityView;
        _dayCounterController = dayCounterController;
        _dayCounterController.OnUpdateDay += NextDay;
    }

    private void NextDay()
    {
        _cityView.People.text = "People: " + ++_cityDatabase.People;
        _cityDatabase.Food += 50f - _cityDatabase.People;
        _cityView.Food.text = "Food: " + _cityDatabase.Food;
        _cityDatabase.Gold += 50f + _cityDatabase.People;
        _cityView.Gold.text = "Gold: " + _cityDatabase.Gold;
        
    }

}
