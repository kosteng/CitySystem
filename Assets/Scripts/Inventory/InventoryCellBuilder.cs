using Items.ResourceItems;
using System.Linq;

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

        public InventoryCellView Build(EResourceItemType type)
        {
            var prefab = _inventoryCellFactory.Create();
            var resourceData = _resourceItemsDatabase.ResourceItemsData.FirstOrDefault(i => i.ResourceItemType == type);
            prefab.Title.text = $"{resourceData.ResourceItemType.ToString()} {resourceData.Amount}";
            prefab.Amount = resourceData.Amount;
            prefab.SetItemType(resourceData.ResourceItemType);
            return prefab;
        }
    }
}