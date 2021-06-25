using Engine.Mediators;
using Engine.UI;
using UnityEngine;

namespace Inventory
{
    public class InventoryPresenter : IAttachableUi, IUpdatable
    {
        private readonly InventoryView _view;

        public InventoryPresenter(InventoryView view)
        {
            _view = view;
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _view.gameObject.SetActive(!_view.gameObject.activeSelf);
        }
    }
}
