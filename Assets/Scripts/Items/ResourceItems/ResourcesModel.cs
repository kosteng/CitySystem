using Items.ResourceItems;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace City
{
    //todo переписать избрать от SO, не хранить ресурсы в SO
    [Serializable]
    public class ResourcesModel
    {
        public float Gold;
        public float Food;
        public float Wood;
        public float Stone;
        public float Iron;
        
        public void ClearData()
        {
            Gold = 0;
            Food = 0;
            Wood = 0;
            Stone = 0;
            Iron = 0;
        }
    }
    
    [Serializable]
    public class ResourceItemPriceInfo
    {
        [SerializeField] private EResourceItemType _itemType;
        [SerializeField] private float _amount;
        public EResourceItemType ItemType => _itemType;
        public float Amount => _amount;

    }
}