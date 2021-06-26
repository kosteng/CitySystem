using System;
using UnityEngine;

namespace Items.ResourceItems
{
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