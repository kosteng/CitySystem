using System;
using System.Collections.Generic;
using System.Linq;

namespace Items.ResourceItems
{
    public interface IResourcesStorage
    {
        void AddResource(EResourceItemType type, float amount);
        void RemoveResource(EResourceItemType type, float amount);
        List<ResourceItemData> ResourceItemsData { get; }
        event Action OnChanced;
    }

    public class ResourcesStorage : IResourcesStorage
    {
        private readonly List<ResourceItemData> _resourceItemsData = new List<ResourceItemData>();

        public List<ResourceItemData> ResourceItemsData => _resourceItemsData;
        public event Action OnChanced;

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

            if (item == null) return;
            item.Amount += amount;
            OnChanced?.Invoke();
        }

        public void RemoveResource(EResourceItemType type, float amount)
        {
            var item = _resourceItemsData.FirstOrDefault(i => i.ResourceItemType == type);

            if (item == null) return;
            item.Amount -= amount;
            OnChanced?.Invoke();
        }
    }
}