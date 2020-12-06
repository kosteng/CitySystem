using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABuildingModel : IBuilding
{
    private readonly CityDatabase _cityDatabase;
    private readonly ABuildingView _view;
    private readonly ResourcesModel _resourcesModel;
    private EBuildingType _buildingType;

    public virtual ABuildingView BuildingView => _view;
    public virtual ResourcesModel Resources => _resourcesModel;
    public virtual EBuildingType BuildingType => _buildingType;

    public ABuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase)
    {
        _cityDatabase = cityDatabase;
        _view = view;
        _resourcesModel = resourcesModel;
    }

    public virtual void Income()
    {
    }

    public virtual void Expense()
    {
    }
}

public class HouseBuildingModel : ABuildingModel
{
    public HouseBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase) : base(view,
        resourcesModel, cityDatabase)
    {
    }

    public override void Income()
    {
        Debug.Log("House");
    }
}

public class SawBuildingModel : ABuildingModel
{
    public SawBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase) : base(view,
        resourcesModel, cityDatabase)
    {

    }

    public override void Income()
    {
        Debug.Log("Saw");
    }
}

public class MineBuildingModel : ABuildingModel
{
    public MineBuildingModel(ABuildingView view, ResourcesModel resourcesModel, CityDatabase cityDatabase) : base(view,
        resourcesModel, cityDatabase)
    {
    }

    public override void Income()
    {
        Debug.Log("Mine");
    }
}