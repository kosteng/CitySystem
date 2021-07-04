using Items.ResourceItems;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCellBuilder : IInventoryCellBuilder
    {
        private readonly IInventoryCellFactory _inventoryCellFactory;
        private readonly ResourceItemsDatabase _resourceItemsDatabase;

        public InventoryCellBuilder(IInventoryCellFactory inventoryCellFactory, ResourceItemsDatabase resourceItemsDatabase)
        {
            _inventoryCellFactory = inventoryCellFactory;
            _resourceItemsDatabase = resourceItemsDatabase;
        }

        public InventoryCellView Build(EResourceItemType type, Transform contentParent, ToggleGroup toggleGroup, EInventoryCellSide side)
        {
            var prefab = _inventoryCellFactory.Create();
            var resourceData = _resourceItemsDatabase.ResourceItemsData.FirstOrDefault(i => i.ResourceItemType == type);
            
            prefab.Init(resourceData, side, toggleGroup);
            prefab.transform.SetParent(contentParent);
            
            return prefab;
        }
    }
}