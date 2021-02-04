using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace UI.BottomPanel
{
    public class BuildingWindowInfoPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingWindowInfoView _view;


        public BuildingWindowInfoPresenter(BuildingWindowInfoView view)
        {
            _view = view;
        }

        public void Show(ABuildingView buildingView)
        {
            _view.gameObject.SetActive(true);
        }
        private void Subscribe()
        {
            Hide();
            _view.Subscribe(Hide);
        }
        public void Hide()
        {
            _view.gameObject.SetActive(false);
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
            Subscribe();
        }
    }
}
