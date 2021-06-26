using UnityEngine;

namespace Inventory
{
    public class InventoryCellFactory : IInventoryCellFactory
    {
        private readonly InventoryCellView _view;

        public InventoryCellFactory(InventoryCellView view)
        {
            _view = view;
        }
        public InventoryCellView Create()
        {
            return Object.Instantiate(_view);
        }
    }
}