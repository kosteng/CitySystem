using System;

public class BottomPanelPresenter
{
    private readonly BottomPanelView _bottomPanalView;
    public event Action OnShowBuildingUIInfoBuyView;

    public BottomPanelPresenter(BottomPanelView bottomPanalView)
    {
        _bottomPanalView = bottomPanalView;
    }

    public void Awake()
    {
        _bottomPanalView.OnClickBuildingsButton += Show;
    }

    public void Show()
    {
        OnShowBuildingUIInfoBuyView?.Invoke();
    }
}