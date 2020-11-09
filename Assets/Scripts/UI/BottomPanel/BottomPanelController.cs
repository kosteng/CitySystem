using System;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace UI.BottomPanel
{
    public class BottomPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BottomPanelView _view;
        public event Action OnShowBuildingUIInfoBuyView;

        public BottomPanelPresenter(BottomPanelView view)
        {
            _view = view;
        }

        private void Show()
        {
            OnShowBuildingUIInfoBuyView?.Invoke();
        }

        public void Dispose()
        {
            _view.Unsubscribe();
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            _view.Subscribe(Show);
        }
    }
}