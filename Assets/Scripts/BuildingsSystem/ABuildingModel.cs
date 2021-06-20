using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Interfaces;
using BuildingsSystem.Views;
using City;
using System;
using UnityEngine;

namespace BuildingsSystem
{
    public class ABuildingModel : IBuilding, IDisposable
    {
        private readonly ABuildingView _view;

        private readonly CityModel _cityModel;
        private EBuildingType _buildingType;
        public event BuildingClickHandler OnBuildingClickHandler;

        public ABuildingView BuildingView => _view;
        public EBuildingType BuildingType => _buildingType;

        public ABuildingModel (BuildingDatabase buildingDatabase, CityModel cityModel)
        {
            _view = buildingDatabase.View;
            _buildingType = buildingDatabase.BuildingType;
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
        public HouseBuildingModel(BuildingDatabase buildingDatabase, CityModel cityModel) : base(buildingDatabase, cityModel)
        {
        }
        
        public override void Income()
        {
            Debug.Log("House");
        }
    }

    public class SawBuildingModel : ABuildingModel
    {
        public SawBuildingModel(BuildingDatabase buildingDatabase, CityModel cityModel) : base(buildingDatabase, cityModel)
        {
        }

        public override void Income()
        {
            Debug.Log("Saw");
        }
    }

    public class MineBuildingModel : ABuildingModel
    {
        public MineBuildingModel(BuildingDatabase buildingDatabase, CityModel cityModel) : base(buildingDatabase, cityModel)
        {
        }

        public override void Income()
        {
            Debug.Log("Mine");
        }
    }

    public class StorageBuildingModel : ABuildingModel
    {
        public StorageBuildingModel(BuildingDatabase buildingDatabase, CityModel cityModel) : base(buildingDatabase, cityModel)
        {
        }
        
        public override void Income()
        {
            Debug.Log("Storage");
        }
    }
}