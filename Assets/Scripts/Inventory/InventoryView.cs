using Engine.UI;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : APanel
    {
        [SerializeField] private SideScrollPanelView _leftSide;
        [SerializeField] private SideScrollPanelView _rightSide;
        [SerializeField] private CharacterInventoryEquipmentView _characterInventoryEquipmentView;
        public CharacterInventoryEquipmentView CharacterInventoryEquipmentView => _characterInventoryEquipmentView;
        public SideScrollPanelView LeftSidePanel => _leftSide;
        public SideScrollPanelView RightSidePanel => _rightSide;

    }
}