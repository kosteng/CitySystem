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
        
        public void Subscribe(Action onCancelClick, Action<EResourceItemType, float> onConfirmClick, Action<float> onSliderValueChanced)
        {
            _cancelButton.onClick.AddListener(onCancelClick.Invoke);
            _confirmButton.onClick.AddListener(() => onConfirmClick.Invoke(_type, _currentAmountResources));  
            _transferSlider.onValueChanged.AddListener(onSliderValueChanced.Invoke);
        }
        public void Show(EResourceItemType type, float amountResources)
        {
            _currentAmountResources = 0f;
            _transferSlider.value = _currentAmountResources;
            _type = type;
            _title.text = _type.ToString();
            _currentAmount.text = _currentAmountResources.ToString();
            _transferSlider.maxValue = amountResources;
            _maxAmount.text = amountResources.ToString();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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