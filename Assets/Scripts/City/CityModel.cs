using Items.ResourceItems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace City
{
    public class CityModel
    {
        private readonly List<ResourceItemData> _resourceItemsData = new List<ResourceItemData>();
        public readonly ResourcesModel ResourcesModel = new ResourcesModel();
        
        public CityModel(ResourceItemsDatabase resourceItemsDatabase)
        {
            foreach (var resourceItemData in resourceItemsDatabase.ResourceItemsData)
            {
                _resourceItemsData.Add(resourceItemData);
            }

            foreach (var resourceItemData in _resourceItemsData)
            {
                Debug.Log(resourceItemData.ResourceItemType.ToString());
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