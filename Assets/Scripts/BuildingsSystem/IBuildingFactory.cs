using BuildingsSystem.Databases;
using BuildingsSystem.Views;
using City;

namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(BuildingDatabase currentBuilding, CityModel cityModel);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}