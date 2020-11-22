using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace UI.BottomPanel
{
    public class BottomPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BottomPanelView _view;
        private readonly BuildingInfoBuyPanelPresenter _buildingInfoBuyPanelPresenter;

        public BottomPanelPresenter(BottomPanelView view, BuildingInfoBuyPanelPresenter buildingInfoBuyPanelPresenter)
        {
            _view = view;
            _buildingInfoBuyPanelPresenter = buildingInfoBuyPanelPresenter;
        }

        private void Show()
        {
            _buildingInfoBuyPanelPresenter.Show();
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