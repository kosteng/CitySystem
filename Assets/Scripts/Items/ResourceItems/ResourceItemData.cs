using System;
using System.ComponentModel;
using UnityEngine;

namespace Items.ResourceItems
{
    [Serializable]
    public class ResourceItemData
    {
        [SerializeField] private float _weight;
        [SerializeField] private string _description;
        public EResourceItemType ResourceItemType;
        public ResourceItemView View;
        [NonSerialized] public float Amount;
        public float Weight => _weight;
        public string Description => _description;


        public ResourceItemData(float weight, EResourceItemType resourceItemType, ResourceItemView view, float amount, string description)
        {
            _weight = weight;
            ResourceItemType = resourceItemType;
            View = view;
            Amount = amount;
            _description = description;
        }
    }
}
