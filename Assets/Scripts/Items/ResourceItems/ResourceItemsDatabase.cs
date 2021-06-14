using UnityEngine;

namespace Items.ResourceItems
{
    [CreateAssetMenu(menuName = "DatabasesSO/ResourceItemsDatabase")]
    public class ResourceItemsDatabase : ScriptableObject
    {
        public ResourceItemData[] ResourceItemsData;
    }
}