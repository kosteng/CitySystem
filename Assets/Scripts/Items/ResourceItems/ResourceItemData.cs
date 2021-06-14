using System;
using UnityEngine;

namespace Items.ResourceItems
{
    [Serializable]
    public class ResourceItemData
    {
        [SerializeField] private float _weight;
        public EResourceItemType ResourceItemType;
        public ResourceItemView View;
        [NonSerialized]  public float Amount;
        public float Weight => _weight;
    }
}