using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : APanel
    {
        [SerializeField] private ScrollRect _scrollVRect;
        [SerializeField] private ToggleGroup _toggleGroup;
        public Transform ScrollView => _scrollVRect.content;
        public ScrollRect ScrollRect => _scrollVRect;
        public ToggleGroup ToggleGroup => _toggleGroup;
    }
}
