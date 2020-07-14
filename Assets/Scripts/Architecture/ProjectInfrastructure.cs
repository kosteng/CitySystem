public class ProjectInfrastructure 
{
    private MonoBehaviourConteiner _monoBehaviourConteiner;
    private readonly DayCounterController _dayCounterController;
    private readonly CityController _cityController;
    private readonly BuildingController _buildingController;
    private readonly BottomPanelPresenter _bottomPanalPresenter;
    private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;

    public ProjectInfrastructure (MonoBehaviourConteiner monoBehaviourConteiner)
    {
        _monoBehaviourConteiner = monoBehaviourConteiner;

        _bottomPanalPresenter = new BottomPanelPresenter(monoBehaviourConteiner.BottomPanalView)
;
        _dayCounterController = new DayCounterController(

            _monoBehaviourConteiner.DayCounterDataBase, 
            _monoBehaviourConteiner.DayCounterView);

        _buildingController = new BuildingController(

            _monoBehaviourConteiner.AllBuildingsDatabase,
            _dayCounterController, 
            _monoBehaviourConteiner.BuildingUIView, 
            _monoBehaviourConteiner.House,
            _monoBehaviourConteiner.SawMill, 
            _monoBehaviourConteiner.Mine);

        _buildingInfoBuyPanelPresenter = new BuildingInfoBuyPanelPresenter(_monoBehaviourConteiner.BuildingUIView,
                                                                           _bottomPanalPresenter,
                                                                           _monoBehaviourConteiner.AllBuildingsDatabase);

        _cityController = new CityController( _monoBehaviourConteiner.CityDatabase,
                                              _monoBehaviourConteiner.CityView,
                                              _dayCounterController,
                                              _buildingController,
                                              _buildingInfoBuyPanelPresenter);
    }

    public void Start()
    {

    }
    public void Awake()
    {
        _cityController.Awake();
        _dayCounterController.Awake();
        _buildingController.Awake();
        _bottomPanalPresenter.Awake();
        _buildingInfoBuyPanelPresenter.Awake();
    }
    public void Update(float deltaTime)
    {
        _dayCounterController.Update(deltaTime);
    }
}
