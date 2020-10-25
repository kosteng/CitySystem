using System;

public class BottomPanelPresenter : IDisposable
{
    private readonly BottomPanelView _bottomPanalView;
    public event Action OnShowBuildingUIInfoBuyView;

    public BottomPanelPresenter(BottomPanelView bottomPanalView)
    {
        _bottomPanalView = bottomPanalView;
        _bottomPanalView.OnClickBuildingsButton += Show;
    }

    public void Show()
    {
        OnShowBuildingUIInfoBuyView?.Invoke();
    }

    public void Dispose()
    {
        _bottomPanalView.OnClickBuildingsButton -= Show;
    }
}