using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using System;
using UnityEngine;

namespace BuildingsSystem
{
    public class ABuildingModel : IBuilding, IDisposable
    {

        private readonly ABuildingView _view;
        private readonly ResourcesModel _resourcesModel;
        private readonly CityModel _cityModel;
        private EBuildingType _buildingType;
        public event BuildingClickHandler OnBuildingClickHandler;

        public ABuildingView BuildingView => _view;
        public ResourcesModel Resources => _resourcesModel;
        public EBuildingType BuildingType => _buildingType;

        public ABuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityModel cityModel,
            EBuildingType buildingType)
        {

            _view = view;
            _buildingType = buildingType;
            _resourcesModel = resourcesModel;
            _cityModel = cityModel;
        }

        public void Subscribe()
        {
            _view.OnBuildingClick += BuildingClickButton;
        }

        public virtual void Income()
        {
        }

        public virtual void Expense()
        {
        }

        private void BuildingClickButton()
        {
            OnBuildingClickHandler?.Invoke(this);
        }

        public void Dispose()
        {
            _view.OnBuildingClick -= BuildingClickButton;
        }
    }

    public class HouseBuildingModel : ABuildingModel
    {
        public HouseBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityModel cityDatabase,
            EBuildingType buildingType) : base(view, resourcesModel, cityDatabase, buildingType)
        {
        }

        public override void Income()
        {
            Debug.Log("House");
        }
    }

    public class SawBuildingModel : ABuildingModel
    {
        public SawBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityModel cityDatabase,
            EBuildingType buildingType) : base(view, resourcesModel, cityDatabase, buildingType)
        {
        }

        public override void Income()
        {
            Debug.Log("Saw");
        }
    }

    public class MineBuildingModel : ABuildingModel
    {
        public MineBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityModel cityDatabase,
            EBuildingType buildingType) : base(view, resourcesModel, cityDatabase, buildingType)
        {
        }

        public override void Income()
        {
            Debug.Log("Mine");
        }
    }

    public class StorageBuildingModel : ABuildingModel
    {

        public StorageBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityModel cityDatabase,
            EBuildingType buildingType) : base(view, resourcesModel, cityDatabase, buildingType)
        {
            
        }
        
        public override void Income()
        {
            Debug.Log("Storage");
        } 
    }
}