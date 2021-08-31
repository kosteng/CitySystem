using Engine.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : APanel
    {
        [SerializeField] private SideScrollPanelView _leftSide;
        [SerializeField] private SideScrollPanelView _rightSide;
        [SerializeField] private CharacterInventoryEquipmentView _characterInventoryEquipmentView;
        [SerializeField] private Button _closeButton;

        public void Subscribe(Action onCloseButton)
        {
            _closeButton.onClick.AddListener(() => onCloseButton?.Invoke());
        }

        public void Unsubscribe()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
        public CharacterInventoryEquipmentView CharacterInventoryEquipmentView => _characterInventoryEquipmentView;
        public SideScrollPanelView LeftSidePanel => _leftSide;
        public SideScrollPanelView RightSidePanel => _rightSide;

    }
}