using System;
using UnityEngine;

namespace Items.ResourceItems
{
    [Serializable]
    public class ResourceItemData
    {
        public EResourceItemType ResourceItemType;
        public ResourceItemView View;
        public float Amount;
        public float Weight;
    }
    
    [CreateAssetMenu(menuName = "DatabasesSO/ResourceItemsDatabase")]
    public class ResourceItemsDatabase : ScriptableObject
    {
        public ResourceItemData[] ResourceItemDatas;
    }
}