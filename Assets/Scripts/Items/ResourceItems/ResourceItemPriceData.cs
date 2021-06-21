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
    
    [Serializable]
    public class ResourceItemPriceDataWithRandom
    {
        [SerializeField] private EResourceItemType _itemType;
        [SerializeField] private int _minAmount;
        [SerializeField] private int _maxAmount;

        public EResourceItemType ItemType => _itemType;
        public int MinAmount => _minAmount;
        public int MaxAmount => _maxAmount;
    }
}