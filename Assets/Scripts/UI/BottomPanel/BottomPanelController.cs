using System;
using UnityEngine;

namespace UI.BottomPanel
{
    public class BottomPanelPresenter : IDisposable
    {
        private readonly BottomPanelView _view;
        public event Action OnShowBuildingUIInfoBuyView;

        public BottomPanelPresenter(BottomPanelView view)
        {
            _view = view;
            _view.Subscribe(Show);
        }

        private void Show()
        {
            OnShowBuildingUIInfoBuyView?.Invoke();
        }

        public void Dispose()
        {
            _view.Unsubscribe();
        }
    }
}