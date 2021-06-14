using System;

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
}