using Engine.UI;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI _totalWeight;


        public Transform LeftSideScroll => _leftSideScroll.content;
        public ToggleGroup LeftSideToggleGroup => _leftSideToggleGroup;
        
        public Transform RightSideScroll => _rightSideScroll.content;
        public ToggleGroup RightSideToggleGroup => _rightSideToggleGroup;

        public void ShowRightSidePanel()
        {
            _rightSideScrollPanel.SetActive(true);
            _characterEquipment.SetActive(false);
        }

        public void ShowCharacterEquipmentPanel()
        {
            _rightSideScrollPanel.SetActive(false);
            _characterEquipment.SetActive(true);
        }

        public void SetWeight(float value)
        {
            _totalWeight.text = value.ToString("F");
        }
    }
}
