using Inventory;
using System.Linq;

namespace Items.ResourceItems
{
    public class ResourceItemsTransfer : IResourceItemsTransfer
    {
        public void Transfer(IResourcesStorage exporter, IResourcesStorage importer, EResourceItemType type, float amount)
        {
            var item = exporter.ResourceItemsData.FirstOrDefault(r => r.ResourceItemType == type);
            if (item?.Amount < amount)
                return;
            exporter.RemoveResource(type, amount);
            importer.AddResource(type, amount);
        }
    }
}