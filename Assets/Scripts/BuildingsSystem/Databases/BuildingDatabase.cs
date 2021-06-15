using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingsSystem.Databases
{
    [Serializable]
    public class BuildingDatabase 
    {
        [SerializeField] private EBuildingType _buildingType;
        [SerializeField] private string _name;
        [SerializeField] private ABuildingView _view;
        [SerializeField] private List<ResourceItemPriceData> _costResourcesData;
        [SerializeField] private List<ResourceItemPriceData> _incomeResourcesData; 
        
        public List<ResourceItemPriceData> CostResourcesData => _costResourcesData;
        public List<ResourceItemPriceData> IncomeResourcesData => _incomeResourcesData;
        public EBuildingType BuildingType => _buildingType;
        public ABuildingView View => _view;
        public Dictionary<EResourceItemType, float> BuildingCost;
        
        //TODO выводить только не нулевые ресурсы
        public string ShowCost()
        {
            var cost = string.Empty;
            
            foreach (var item in _costResourcesData)
            {
                cost += $"{item.ItemType.ToString()}: {item.Amount} ";
            }

            return $"Cost: {cost}";
        }

        public void VerifycationDictionary()
        {
            if (_costResourcesData == null)
                _costResourcesData = new List<ResourceItemPriceData>();
        
            BuildingCost = new Dictionary<EResourceItemType, float>();
            foreach (var item in _costResourcesData)
            {
                BuildingCost.Add(item.ItemType, item.Amount);
            }
        }
    }
}