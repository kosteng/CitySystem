using BuildingsSystem.Enums;
using System;
using Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingBuyPanelView : APanel
    {
        [SerializeField] private Button _buyBuildingButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _nameBuildingText;
        [SerializeField] private TextMeshProUGUI _costBuildingText;
        [SerializeField] private Transform _buildingButtonsPanel;
       
        private EBuildingType _currentType;
        public Transform BuildingButtonsPanel => _buildingButtonsPanel;
        public delegate void BuildingTypeHandler(EBuildingType type);

        public void Subscribe(Action onBuyButton, Action onCloseButton, BuildingTypeHandler onBuyBuildingClickButton)
        {
            _buyBuildingButton.onClick.AddListener(() => onBuyBuildingClickButton?.Invoke(_currentType));
            _buyBuildingButton.onClick.AddListener(onBuyButton.Invoke);
            _closeButton.onClick.AddListener(onCloseButton.Invoke);
        }
        public void Unsubscribe()
        {
            _buyBuildingButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
        }

        public void SetName(string name)
        {
            _nameBuildingText.text = name;
        }

        public void SetCost(string cost)
        {
            _costBuildingText.text = cost;
        }
    }
}