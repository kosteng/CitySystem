using Engine.UI;
using Items.ResourceItems;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class TransferPopupView : APanel
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _currentAmount;
        [SerializeField] private Text _maxAmount;
        [SerializeField] private Slider _transferSlider;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Button _confirmButton;

        private float _currentAmountResources;
        private EResourceItemType _type;
        private EInventoryCellSide _side;
        
        public void Subscribe(Action onCancelClick, Action<EResourceItemType, float, EInventoryCellSide> onConfirmClick,
            Action<float> onSliderValueChanced)
        {
            _cancelButton.onClick.AddListener(onCancelClick.Invoke);
            _confirmButton.onClick.AddListener(() => onConfirmClick.Invoke(_type, _currentAmountResources, _side));
            _transferSlider.onValueChanged.AddListener(onSliderValueChanced.Invoke);
        }

        public void Show(InventoryCellView cell, float amountResources)
        {
            _currentAmountResources = 0f;
            _transferSlider.value = _currentAmountResources;
            _type = cell.ItemType;
            _side = cell.InventoryCellSide;
            _title.text = _type.ToString();
            _currentAmount.text = _currentAmountResources.ToString();
            _transferSlider.maxValue = amountResources;
            _maxAmount.text = amountResources.ToString();
            Show();
        }


        public void SetCurrentAmount(float value)
        {
            _currentAmountResources = value;
            _currentAmount.text = _currentAmountResources.ToString();
        }

        public void UnSubscribe()
        {
            _cancelButton.onClick.RemoveAllListeners();
            _confirmButton.onClick.RemoveAllListeners();
            _transferSlider.onValueChanged.RemoveAllListeners();
        }
    }
}