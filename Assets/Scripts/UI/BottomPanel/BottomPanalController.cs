public class BottomPanalController
{
    private readonly BuildingUIView _buildingUIView; 
    private readonly BottomPanalView _bottomPanalView;

    public BottomPanalController(BottomPanalView bottomPanalView, BuildingUIView buildingUIView)
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