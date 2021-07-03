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
        [SerializeField] private GameObject _rightSideScrollPanel;
        [SerializeField] private GameObject _characterEquipment;

        private EInventoryRightSideState _inventoryRightSideState; //todo это не логика для вьюху, лучше вынести в презентер
        public EInventoryRightSideState InventoryRightSideState => _inventoryRightSideState;
        public Transform LeftSideScroll => _leftSideScroll.content;
        public ToggleGroup LeftSideToggleGroup => _leftSideToggleGroup;
        
        public Transform RightSideScroll => _rightSideScroll.content;
        public ToggleGroup RightSideToggleGroup => _rightSideToggleGroup;

        public void ShowRightSidePanel()
        {
            _inventoryRightSideState = EInventoryRightSideState.Change;
            _rightSideScrollPanel.SetActive(true);
            _characterEquipment.SetActive(false);
        }

        public void ShowCharacterEquipmentPanel()
        {
            _inventoryRightSideState = EInventoryRightSideState.Equipment;
            _rightSideScrollPanel.SetActive(false);
            _characterEquipment.SetActive(true);
        }
    }
}
