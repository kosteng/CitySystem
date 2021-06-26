using Engine.Mediators;
using Engine.UI;
using Items.ResourceItems;
using UnityEngine;

namespace Inventory
{
    public class InventoryPresenter : IAttachableUi, IUpdatable
    {
        private readonly InventoryView _view;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;

        public InventoryPresenter(InventoryView view, IInventoryCellBuilder inventoryCellBuilder)
        {
            _view = view;
            _inventoryCellBuilder = inventoryCellBuilder;
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

            if (Input.GetKeyDown(KeyCode.B))
                for (int i = 0; i < 10; i++)
                {
                   var cell = _inventoryCellBuilder.Build(EResourceItemType.Stick);
                   cell.transform.SetParent(_view.Parent);
                }

        }
    }
}
