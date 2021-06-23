using City;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items.InteractItems
{
    [CreateAssetMenu(menuName = "DatabasesSO/InteractItemsDatabase")]

    public class InteractItemsDatabase : ScriptableObject
    {
        public InteractItemsData[] InteractItemsData;
    }
    
[Serializable]
    public class InteractItemsData
    {
        [SerializeField] private EInteractItemType _type;
        [SerializeField] private InteractableItemView _itemView;
        [SerializeField] private ResourceItemPriceDataWithRandom[] resourceItemsPriceDataWithRandom;
        
        public EInteractItemType Type => _type;
        public InteractableItemView ItemView => _itemView;
        public ResourceItemPriceDataWithRandom[] ResourceItemsPriceDataWithRandom => resourceItemsPriceDataWithRandom;
    }
}
