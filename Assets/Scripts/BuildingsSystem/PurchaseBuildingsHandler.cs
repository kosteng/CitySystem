using City;
using Items.ResourceItems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingsSystem
{
    public class PurchaseBuildingsHandler
    {
        public void PurchaseBuilding(ResourcesStorage purchaser, List<ResourceItemPriceData> cost)
        {
            foreach (var buildingCost in cost)
            {
                var cityResource =
                    purchaser.ResourceItemsData.FirstOrDefault(i => i.ResourceItemType == buildingCost.ItemType);

                cityResource.Amount -= buildingCost.Amount;
                
                Debug.Log($"Куплено {cityResource.Amount}");
            }
        }

        public bool TryPurchaseBuilding(ResourcesStorage purchaser, List<ResourceItemPriceData> cost)
        {
            var canPurchase = true;
            
            foreach (var buildingCost in cost)
            {
                var cityResource =
                    purchaser.ResourceItemsData.FirstOrDefault(i => i.ResourceItemType == buildingCost.ItemType);
                
                if (cityResource != null && !(cityResource.Amount < buildingCost.Amount)) continue;
                
                Debug.Log($"Не хватает {cityResource.ResourceItemType.ToString()} Текущее количество {cityResource.Amount}");

                canPurchase = false;
            }

            return canPurchase;
        }
    }
}