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
        
        private EResourceItemType _itemType;
        
        public Text Title;
        public float Amount;
        public EResourceItemType ItemType => _itemType;

        public void SetItemType(EResourceItemType type)
        {
            _itemType = type;
        }

        public void Subscribe(Action<bool, InventoryCellView> onCellClick)
        {
            _toggle.onValueChanged.AddListener(b => onCellClick?.Invoke(b, this));
        }
        
        public void Unsubscribe()
        {
            _toggle.onValueChanged.RemoveAllListeners();
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