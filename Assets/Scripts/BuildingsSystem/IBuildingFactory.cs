using BuildingsSystem.Databases;
using BuildingsSystem.Views;

namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityDatabase cityDatabase);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}