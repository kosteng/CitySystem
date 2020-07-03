public class ProjectInfrastructure 
{
    private MonoBehaviourConteiner _monoBehaviourConteiner;
    private readonly DayCounterController _dayCounterController;
    private readonly CityController _cityController;
    private readonly BuildingController _buildingController;
    private readonly BottomPanalController _bottomPanalController;
    public ProjectInfrastructure (MonoBehaviourConteiner monoBehaviourConteiner)
    {
        _monoBehaviourConteiner = monoBehaviourConteiner;

        _bottomPanalController = new BottomPanalController(
            _monoBehaviourConteiner.BottomPanalView,
            _monoBehaviourConteiner.BuildingUIView);

        _dayCounterController = new DayCounterController(
            _monoBehaviourConteiner.DayCounterDataBase, 
            _monoBehaviourConteiner.DayCounterView);

        _buildingController = new BuildingController(
            _monoBehaviourConteiner.AllBuildingsDatabase,
            _dayCounterController, 
            _monoBehaviourConteiner.BuildingUIView, 
            _monoBehaviourConteiner.House,
            _monoBehaviourConteiner.SawMill, 
            _monoBehaviourConteiner.Mine,
            _bottomPanalController);

        _cityController = new CityController(
            _monoBehaviourConteiner.CityDatabase,
            _monoBehaviourConteiner.CityView,
            _dayCounterController,
            _buildingController);

        _bottomPanalController = new BottomPanalController(
            _monoBehaviourConteiner.BottomPanalView, 
            _monoBehaviourConteiner.BuildingUIView);
    }

    public void Start()
    {

    }
    public void Awake()
    {
        _cityController.Awake();
        _dayCounterController.Awake();
        _buildingController.Awake();
        _bottomPanalController.Awake();
    }
    public void Update(float deltaTime)
    {
        _dayCounterController.Update(deltaTime);
    }
}
