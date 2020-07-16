using System;
public class BuildingInfoBuyPanelPresenter
{
    private readonly BuildingUIInfoBuyView _buildingUIInfoBuyView;
    private readonly BottomPanelPresenter _bottomPanelPresenter;
    private readonly AllBuildingsDatabase _allBuildingsDatabase;
    private readonly BuidingsStorageHandler _buidingsStorageHandler;
    private ABuildingDatabase _currentBuild;

    public event Action OnBuyBuilding;

    public BuildingInfoBuyPanelPresenter(BuildingUIInfoBuyView buildingUIInfoBuyView, 
                                         BottomPanelPresenter bottomPanelPresenter, 
                                         AllBuildingsDatabase allBuildingsDatabase,
                                         BuidingsStorageHandler buidingsStorageHandler)
    {
        _buildingUIInfoBuyView = buildingUIInfoBuyView;
        _bottomPanelPresenter = bottomPanelPresenter;
        _allBuildingsDatabase = allBuildingsDatabase;
        _buidingsStorageHandler = buidingsStorageHandler; 
    }

    public void Awake()
    {
        _bottomPanelPresenter.OnShowBuildingUIInfoBuyView += Show;
        _buildingUIInfoBuyView.OnBuildingClickButton += ShowBuildingData;
        _buildingUIInfoBuyView.OnCloseInfoPanelBuildingClickButton += CloseInfoBuyPanel;
        _buildingUIInfoBuyView.OnBuyBuildingClickButton += BuyBuilding;
        _buildingUIInfoBuyView.gameObject.SetActive(false);
    }

    private void Show()
    {
        _buildingUIInfoBuyView.gameObject.SetActive(!_buildingUIInfoBuyView.gameObject.activeSelf);
    }

    private void CloseInfoBuyPanel()
    {
        _buildingUIInfoBuyView.gameObject.SetActive(false);
    }

    private void ShowBuildingData(EBuildingType buildingType)
    {
        var build = _allBuildingsDatabase.Buildings[buildingType];
        _buildingUIInfoBuyView.SetNameTextInfoPanel(build.Name);
        _buildingUIInfoBuyView.SetCostTextInfoPanel(build.ShowCost());
    }

    private void BuyBuilding(EBuildingType buildingType)
    {
        var build = _allBuildingsDatabase.Buildings[buildingType];
        build.PayBuilding();
    //    if (!build.IsBuy)
      //      return;
      if (buildingType == EBuildingType.House)
        _buidingsStorageHandler.HouseBuildings.Add((HouseBuildingDatabase)_allBuildingsDatabase.Buildings[EBuildingType.House]);
        OnBuyBuilding?.Invoke();
    }
}