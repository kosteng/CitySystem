using System;
using UnityEngine;

namespace Items.ResourceItems
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