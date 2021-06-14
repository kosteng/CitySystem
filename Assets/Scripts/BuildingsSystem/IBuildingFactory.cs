using BuildingsSystem.Databases;
using BuildingsSystem.Views;
using City;

namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityModel cityModel);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}