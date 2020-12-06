using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModel : IBuilding
{
    private readonly CityDatabase _cityDatabase;
    private readonly ABuildingView _view;
    private readonly ResourcesesModel _resourcesesModel;
    private ABuildingView _buildingView;

    public BuildingModel(ABuildingView view, ResourcesesModel resourcesesModel, CityDatabase cityDatabase)
    {
        _cityDatabase = cityDatabase;
        _view = view;
        _resourcesesModel = resourcesesModel;
    }

    public ABuildingView BuildingView => _view;

    public ResourcesesModel Resourceses => _resourcesesModel;

    public void Income()
    {
        _cityDatabase.Model.Gold +=  _resourcesesModel.Gold;
    }
}