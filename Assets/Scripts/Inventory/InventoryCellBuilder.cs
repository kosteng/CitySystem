using Items.ResourceItems;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public interface IInventoryCellBuilder
    {
        InventoryCellView Build(EResourceItemType type);
    }
    public class InventoryCellBuilder : IInventoryCellBuilder
    {
        private readonly IInventoryCellFactory _inventoryCellFactory;
        private readonly ResourceItemsDatabase _resourceItemsDatabase;

        public InventoryCellBuilder(IInventoryCellFactory inventoryCellFactory, ResourceItemsDatabase resourceItemsDatabase)
        {
            _inventoryCellFactory = inventoryCellFactory;
            _resourceItemsDatabase = resourceItemsDatabase;
        }

        public InventoryCellView Build(EResourceItemType type)
        {
            var prefab = _inventoryCellFactory.Create();
            var resourceData = _resourceItemsDatabase.ResourceItemsData.FirstOrDefault(i => i.ResourceItemType == type);
            Debug.Log(resourceData.ResourceItemType.ToString());
            prefab.Title.text = $"{resourceData.ResourceItemType.ToString()} " +
                                $"{resourceData.Amount}";
            return prefab;
        }
    }
}