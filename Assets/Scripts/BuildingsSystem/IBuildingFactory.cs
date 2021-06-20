using BuildingsSystem.Databases;
using BuildingsSystem.Interfaces;
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