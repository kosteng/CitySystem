﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Items.ResourceItems
{
    public interface IResourcesStorage
    {
        float GetAmountResource(EResourceItemType type);
        void AddResource(EResourceItemType type, float amount);
        void RemoveResource(EResourceItemType type, float amount);
        List<ResourceItemData> ResourceItemsData { get; }
        float GetTotalWeight();
        float GetResourceWeight(EResourceItemType type);
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
                _resourceItemsData.Add(new ResourceItemData(resourceItemData.Weight,
                    resourceItemData.ResourceItemType,
                    resourceItemData.View,
                    resourceItemData.Amount));

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
                
        public float GetTotalWeight()
        {
            return _resourceItemsData.Sum(i => i.Weight * i.Amount);
        }

        public float GetResourceWeight(EResourceItemType type)
        {
            return _resourceItemsData.Where(itemData => itemData.ResourceItemType == type)
                .Select(itemData => itemData.Amount * itemData.Weight).FirstOrDefault();
        }
        
        public float GetAmountResource(EResourceItemType type)
        {
            return _resourceItemsData.FirstOrDefault(i => i.ResourceItemType == type).Amount;
        }

    }
}