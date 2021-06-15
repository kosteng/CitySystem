using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ResourceItemPriceData = City.ResourceItemPriceData;

namespace BuildingsSystem.Databases
{
    [CreateAssetMenu(menuName = "DatabasesSO/AllBuildingsDatabase")]
    public class AllBuildingsDatabase : ScriptableObject
    {
        [SerializeField] private List<BuildingDatabase> _buildingsDatabase;
        public List<BuildingDatabase> BuildingsDatabase => _buildingsDatabase;

        private void Awake()
        {
            Debug.Log("Awake");
            foreach (var buildingDatabase in _buildingsDatabase)
            {
                buildingDatabase.VerifycationDictionary();
            }
        }

        void Start()
        {
            Debug.Log("Start");
        }
    }

    [Serializable]
    public class BuildingDatabase 
    {
        [SerializeField] private EBuildingType _buildingType;
        [SerializeField] private string _name;
        [SerializeField] private ABuildingView _view;
        [SerializeField] private ResourcesModel _costResources;
        [SerializeField] private ResourcesModel _incomeResources;
        [SerializeField] private List<ResourceItemPriceData> _costResourcesData;
        [SerializeField] private List<ResourceItemPriceData> _incomeResourcesData; 
        public List<ResourceItemPriceData> CostResourcesData => _costResourcesData;
        public List<ResourceItemPriceData> IncomeResourcesData => _incomeResourcesData;
        public ResourcesModel CostResources => _costResources;
        public ResourcesModel IncomeResources => _incomeResources;
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