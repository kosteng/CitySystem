using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : APanel
    {
        [SerializeField] private ScrollRect _leftSideScroll;
        [SerializeField] private ToggleGroup _leftSideToggleGroup;
        
        [SerializeField] private ScrollRect _rightSideScroll;
        [SerializeField] private ToggleGroup _rightSideToggleGroup;

        public Transform LeftSideScroll => _leftSideScroll.content;
        public ToggleGroup LeftSideToggleGroup => _leftSideToggleGroup;
        
        public Transform RightSideScroll => _rightSideScroll.content;
        public ToggleGroup RightSideToggleGroup => _rightSideToggleGroup;
    }
}
