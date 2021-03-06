﻿using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonView : APanel
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Button _button;
    [SerializeField] private EBuildingType _buildingType;
    
    public delegate void BuildingTypeHandler(EBuildingType type);

    public event BuildingTypeHandler OnBuildingClickButton;
    public EBuildingType BuildingType => _buildingType;
    public void SetName(string name)
    {
        _nameText.text = name;
    }
    public void Subscribe()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnBuildingClickButton?.Invoke(_buildingType);
    }

    public void SetBuildingType(EBuildingType type)
    {
        _buildingType = type;
    }

    public void Unsubscribe()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
}
