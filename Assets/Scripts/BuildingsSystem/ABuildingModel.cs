using System;
using UnityEngine;

public class ABuildingModel : IBuilding, IDisposable
{
    private readonly CityDatabase _cityDatabase;
    private readonly ABuildingView _view;
    private readonly ResourcesModel _resourcesModel;
    private EBuildingType _buildingType;
    public event BuildingClickHandler OnBuildingClickHandler;

    public virtual ABuildingView BuildingView => _view;
    public virtual ResourcesModel Resources => _resourcesModel;
    public virtual EBuildingType BuildingType => _buildingType;

    public ABuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase,
        EBuildingType buildingType)
    {
        _cityDatabase = cityDatabase;
        _view = view;
        _buildingType = buildingType;
        _resourcesModel = resourcesModel;
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
    public HouseBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase,
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
    public SawBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase,
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
    public MineBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase,
        EBuildingType buildingType) : base(view, resourcesModel, cityDatabase, buildingType)
    {
    }

    public override void Income()
    {
        Debug.Log("Mine");
    }
}