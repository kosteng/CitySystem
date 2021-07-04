﻿using Items.ResourceItems;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCellView : MonoBehaviour
    {
        [SerializeField] private Image _cellBorder;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _amount;
        [SerializeField] private TextMeshProUGUI _weight;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Button _transferButton;

        private EResourceItemType _itemType;
        private EInventoryCellSide _cellSide;

        public EResourceItemType ItemType => _itemType;
        public EInventoryCellSide InventoryCellSide => _cellSide;

        public void Subscribe(Action<bool, InventoryCellView, EInventoryCellSide> onCellClick, Action<InventoryCellView, EInventoryCellSide> onButtonClick)
        {
            _toggle.onValueChanged.AddListener(b => onCellClick?.Invoke(b, this, _cellSide));

            _transferButton.onClick.AddListener(() => onButtonClick?.Invoke(this, _cellSide));
        }

        public void Init(ResourceItemData itemData, EInventoryCellSide side, ToggleGroup toggleGroup)
        {
            _title.text = itemData.ResourceItemType.ToString();
            _amount.text = itemData.Amount.ToString();
            _weight.text = itemData.Weight.ToString("0.##");
            _itemType = itemData.ResourceItemType;
            _cellSide = side;
            _toggle.group = toggleGroup;
        }

        public void Unsubscribe()
        {
            _toggle.onValueChanged.RemoveAllListeners();
            _transferButton.onClick.RemoveAllListeners();
        }

        public void Refresh(float amount, float weight)
        {
            _amount.text = amount.ToString();
            _weight.text = weight.ToString("0.##");
        }

        public void SetColor(bool isSelected)
        {
            _cellBorder.color = isSelected ? Color.green : Color.magenta;
        }
    }
}