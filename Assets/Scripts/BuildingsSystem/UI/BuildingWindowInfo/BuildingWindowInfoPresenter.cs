using System;
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

        public void Show(ABuildingModel buildingModel)
        {
            _view.gameObject.SetActive(true);
            _view.SetName(buildingModel.BuildingType.ToString());
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
