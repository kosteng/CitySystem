using Building;
using Building.UI.BuildingInfoBuyPanel;

namespace Architecture
{
    public class ProjectInfrastructure
    {
        private MonoBehaviourConteiner _monoBehaviourConteiner;
        private readonly DayCounterController _dayCounterController;
        private readonly CityController _cityController;
        private readonly BuildingController _buildingController;
        private readonly BottomPanelPresenter _bottomPanalPresenter;
        private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;
        private readonly BuildinsStorage _buildinsStorage;


        public ProjectInfrastructure(MonoBehaviourConteiner monoBehaviourConteiner)
        {
            _monoBehaviourConteiner = monoBehaviourConteiner;
            _buildinsStorage = new BuildinsStorage(_monoBehaviourConteiner.HouseBuildingView);
            _bottomPanalPresenter = new BottomPanelPresenter(_monoBehaviourConteiner.BottomPanelView);

            _dayCounterController = new DayCounterController(
                _monoBehaviourConteiner.DayCounterDataBase,
                _monoBehaviourConteiner.DayCounterView);


            _buildingInfoBuyPanelPresenter = new BuildingInfoBuyPanelPresenter(
                _monoBehaviourConteiner.BuildingUIView,
                _bottomPanalPresenter,
                _buildinsStorage,
                _monoBehaviourConteiner.BuildingFactory,
                _monoBehaviourConteiner.AllBuildingsDatabase);

            _buildingController = new BuildingController(
                _dayCounterController, _buildingInfoBuyPanelPresenter, _monoBehaviourConteiner.HouseBuildingView);

            _cityController = new CityController(
                _monoBehaviourConteiner.CityDatabase,
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
}