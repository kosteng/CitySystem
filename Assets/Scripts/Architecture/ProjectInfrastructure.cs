public class ProjectInfrastructure 
{
    private MonoBehaviourConteiner _monoBehaviourConteiner;
    private readonly DayCounterController _dayCounterController;
    private readonly CityController _cityController;
    public ProjectInfrastructure (MonoBehaviourConteiner monoBehaviourConteiner)
    {
        _monoBehaviourConteiner = monoBehaviourConteiner;
        _dayCounterController = new DayCounterController(
            _monoBehaviourConteiner.DayCounterDataBase, 
            _monoBehaviourConteiner.DayCounterView);

        _cityController = new CityController(
            _monoBehaviourConteiner.CityDatabase,
            _monoBehaviourConteiner.CityView,
            _dayCounterController);
    }

    public void Start()
    {

    }
    public void Awake()
    {
        _cityController.Awake();
        _dayCounterController.Awake();
    }
    public void Update(float deltaTime)
    {
        _dayCounterController.Update(deltaTime);
    }
}
