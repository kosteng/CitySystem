﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingBuyPanel : MonoBehaviour
    {
        [SerializeField] private Button _houseBuildingButton;
        [SerializeField] private Button _sawMillBuildingButton;
        [SerializeField] private Button _mineBuildingButton;
        [SerializeField] private Button _buyBuildingButton;
        [SerializeField] private Button _closeInfoPanelButton;
        [SerializeField] private Text _nameBuildingText;
        [SerializeField] private Text _costBuildingText;

        private EBuildingType _currentType;

        public delegate void BuildingTypeHandler(EBuildingType type);

        public event BuildingTypeHandler OnBuildingClickButton;
        public event BuildingTypeHandler OnBuyBuildingClickButton;
        public event Action OnCloseInfoPanelBuildingClickButton;

        // public void Subscribe(Action onHouseButton, 
        //     Action onSawButton, 
        //     Action onMineButton,
        //     Action onBuyButton, 
        //     Action onCloseButton)
        // {
        //     _houseBuildingButton.onClick.AddListener(onHouseButton.Invoke);
        //     _sawMillBuildingButton.onClick.AddListener(onSawButton.Invoke);
        //     _mineBuildingButton.onClick.AddListener(onMineButton.Invoke);
        //     _buyBuildingButton.onClick.AddListener(onBuyButton.Invoke);
        //     _closeInfoPanelButton.onClick.AddListener(onCloseButton.Invoke);
        // }
        // public void Unsubscribe()
        // {
        //     _houseBuildingButton.onClick.RemoveAllListeners();
        //     _sawMillBuildingButton.onClick.RemoveAllListeners();
        //     _mineBuildingButton.onClick.RemoveAllListeners();
        //     _buyBuildingButton.onClick.RemoveAllListeners();
        //     _closeInfoPanelButton.onClick.RemoveAllListeners();
        // }
        public void HouseBuildingClick()
        {
            _currentType = EBuildingType.House;
            OnBuildingClickButton?.Invoke(EBuildingType.House);
        }

        public void SawMillBuildingClick()
        {
            _currentType = EBuildingType.SawMill;
            OnBuildingClickButton?.Invoke(EBuildingType.SawMill);
        }

        public void MineBuildingClick()
        {
            _currentType = EBuildingType.Mine;
            OnBuildingClickButton?.Invoke(EBuildingType.Mine);
        }

        public void BuyBuildingClick()
        {
            OnBuyBuildingClickButton?.Invoke(_currentType);
        }

        public void CloseInfoPanelBuildingClick()
        {
            OnCloseInfoPanelBuildingClickButton?.Invoke();
        }

        public void HouseBuildingButtonSetActive(bool value)
        {
            _houseBuildingButton.gameObject.SetActive(value);
        }

        public void SawMillBuildingButtonSetActive(bool value)
        {
            _sawMillBuildingButton.gameObject.SetActive(value);
        }

        public void MineBuildingButtonSetActive(bool value)
        {
            _mineBuildingButton.gameObject.SetActive(value);
        }

        public void SetNameTextInfoPanel(string name)
        {
            _nameBuildingText.text = name;
        }

        public void SetCostTextInfoPanel(string cost)
        {
            _costBuildingText.text = cost;
        }
    }
}