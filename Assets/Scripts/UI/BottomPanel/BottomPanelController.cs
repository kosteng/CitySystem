public class BottomPanelController
{
    private readonly BuildingUIInfoBuyView _buildingUIView; 
    private readonly BottomPanelView _bottomPanalView;

    public BottomPanelController(BottomPanelView bottomPanalView, BuildingUIInfoBuyView buildingUIView)
    {
        _bottomPanalView = bottomPanalView;
        _buildingUIView = buildingUIView;
    }

    public void Awake()
    {
        _bottomPanalView.OnClickBuildingsButton += Show;
    }

    public void Show()
    {
        _buildingUIView.gameObject.SetActive(!_buildingUIView.gameObject.activeSelf);
    }
}