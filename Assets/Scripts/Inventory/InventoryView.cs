using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : APanel
    {
        [SerializeField] private ScrollRect _scrollVRect;
        public Transform ScrollView => _scrollVRect.content;
    }
}
