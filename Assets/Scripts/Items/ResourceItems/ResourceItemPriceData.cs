using Items.ResourceItems;
using System;
using UnityEngine;

namespace City
{
    [Serializable]
    public class ResourceItemPriceData
    {
        [SerializeField] private EResourceItemType _itemType;
        [SerializeField] private float _amount;
        public EResourceItemType ItemType => _itemType;
        public float Amount => _amount;
    }
}