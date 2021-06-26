using City;
using Engine.Mediators;
using Engine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryPresenter : IAttachableUi, IUpdatable
    {
        private readonly InventoryView _view;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;
        private readonly CityModel _cityModel;
        private List<InventoryCellView> _cells = new List<InventoryCellView>();
        public InventoryPresenter(InventoryView view, IInventoryCellBuilder inventoryCellBuilder, CityModel cityModel)
        {
            _view = view;
            _inventoryCellBuilder = inventoryCellBuilder;
            _cityModel = cityModel;
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
                foreach (var resourceItemData in _cityModel.ResourceItemsData)
                {
                    if (cell.ItemType != resourceItemData.ResourceItemType)
                        continue;
                    
                    cell.Amount = resourceItemData.Amount;
                    cell.RefreshAmount();
                    
                    break;
                }
            }
        }
        
        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _view.gameObject.SetActive(!_view.gameObject.activeSelf);

            if (Input.GetKeyDown(KeyCode.B))
            {
                if(_cells.Count > 0)
                    return;
                foreach (var itemData in _cityModel.ResourceItemsData)
                {
                    var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType);
                    cell.transform.SetParent(_view.ScrollView);
                    _cells.Add(cell);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                RefreshData();
                _cells[4].gameObject.SetActive(!_cells[4].gameObject.activeSelf);
            }
        }
    }
}