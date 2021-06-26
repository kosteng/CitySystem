using System.Collections.Generic;
using System.Linq;

namespace Items.ResourceItems
{
    public class ResourcesStorage
    {
        private readonly List<ResourceItemData> _resourceItemsData = new List<ResourceItemData>();
        public List<ResourceItemData> ResourceItemsData => _resourceItemsData;
        
        public ResourcesStorage(ResourceItemsDatabase resourceItemsDatabase)
        {
            foreach (var resourceItemData in resourceItemsDatabase.ResourceItemsData)
            {
                _resourceItemsData.Add(resourceItemData);
            }
        }

        public void AddResource(EResourceItemType type, float amount)
        {
            var item = _resourceItemsData.FirstOrDefault(i => i.ResourceItemType == type);
            
            if (item != null) 
                item.Amount += amount;
        }
    }
}