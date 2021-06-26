using City;
using Engine.Mediators;
using Engine.UI;
using Items.ResourceItems;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public class InventoryPresenter : IAttachableUi, IUpdatable, IInitializable
    {
        private readonly InventoryView _view;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;
        private readonly ResourcesStorage _resourcesStorage;
        private List<InventoryCellView> _cells = new List<InventoryCellView>();
        public InventoryPresenter(InventoryView view, IInventoryCellBuilder inventoryCellBuilder, ResourcesStorage resourcesStorage)
        {
            _view = view;
            _inventoryCellBuilder = inventoryCellBuilder;
            _resourcesStorage = resourcesStorage;
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        private void RefreshData()
        {
            foreach (var cell in _cells)
            {
                foreach (var resourceItemData in _resourcesStorage.ResourceItemsData)
                {
                    if (cell.ItemType != resourceItemData.ResourceItemType)
                        continue;
                    
                    cell.Amount = resourceItemData.Amount;
                    cell.gameObject.SetActive(cell.Amount > 0);

                    cell.RefreshAmount();
                    
                    break;
                }
            }
        }
        
        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_view.gameObject.activeSelf)
                {
                    RefreshData();
                }
                _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                if(_cells.Count > 0)
                    return;
                foreach (var itemData in _resourcesStorage.ResourceItemsData)
                {
                    var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType);
                    cell.transform.SetParent(_view.ScrollView);
                    _cells.Add(cell);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                RefreshData();
            }
        }

        public void Initialize()
        {
            if(_cells.Count > 0)
                return;
            foreach (var itemData in _resourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType);
                cell.transform.SetParent(_view.ScrollView);
                _cells.Add(cell);
            }
        }
    }
}