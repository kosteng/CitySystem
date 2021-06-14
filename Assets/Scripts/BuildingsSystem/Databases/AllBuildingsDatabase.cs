using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "DatabasesSO/AllBuildingsDatabase")]
public class AllBuildingsDatabase : ScriptableObject
{
    [SerializeField] private List<BuildingDatabase> _buildingsDatabase;
    public List<BuildingDatabase> BuildingsDatabase => _buildingsDatabase;
}

[Serializable]
public class BuildingDatabase
{
    [SerializeField] private EBuildingType _buildingType;
    [SerializeField] private string _name;
    [SerializeField] private ABuildingView _view;
    [SerializeField] private ResourcesModel costResources;
    [SerializeField] private ResourcesModel incomeResources;

    public ResourcesModel CostResources => costResources;

    public ResourcesModel IncomeResources => incomeResources;

    //TODO выводить только не нулевые ресурсы
    public string ShowCost()
    {
        return $"Cost: Gold: {costResources.Gold} Wood: {costResources.Wood} Stone: {costResources.Stone}";
    }

    public EBuildingType BuildingType => _buildingType;

    public ABuildingView View => _view;
}