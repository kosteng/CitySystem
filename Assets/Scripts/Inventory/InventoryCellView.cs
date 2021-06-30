using Items.ResourceItems;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCellView : MonoBehaviour
    {
        [SerializeField] private Image _cellBorder;
        [SerializeField] private Text _amount;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Button _transferButton;
        
        private EResourceItemType _itemType;
        private EInventoryCellSide _cellSide;
        public Text Title;
        public float Amount;
        public EResourceItemType ItemType => _itemType;
        public EInventoryCellSide InventoryCellSide => _cellSide;
        public void SetItemType(EResourceItemType type)
        {
            _itemType = type;
        }       

        public void Subscribe(Action<bool, InventoryCellView, EInventoryCellSide> onCellClick, Action<InventoryCellView, EInventoryCellSide> onButtonClick)
        {
            _toggle.onValueChanged.AddListener(b => onCellClick?.Invoke(b, this, _cellSide));

            _transferButton.onClick.AddListener(() => onButtonClick?.Invoke(this, _cellSide));

        }

        public void SetCellSide(EInventoryCellSide side)
        {
            _cellSide = side;
        }
        public void Unsubscribe()
        {
            _toggle.onValueChanged.RemoveAllListeners();
            _transferButton.onClick.RemoveAllListeners();
        }

        public void RefreshAmount()
        {
            _amount.text = Amount.ToString();
        }

        public void SetToggleGroup(ToggleGroup toggleGroup)
        {
            _toggle.group = toggleGroup;
        }

        public void SetColor(bool isSelected)
        {
            _cellBorder.color = isSelected ? Color.green : Color.magenta;
        }
    }
}