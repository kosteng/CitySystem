using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "DatabasesSO/InteractItemsDatabase")]

    public class InteractItemsDatabase : ScriptableObject
    {
        [SerializeField] private InteractableItemView[] _itemViews;
        public InteractableItemView[] InteractableItemViews => _itemViews;
    }
}
