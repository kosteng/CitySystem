using BuildingsSystem.Databases;
using BuildingsSystem.Interfaces;
using BuildingsSystem.Views;
using City;
using Items.ResourceItems;

namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(BuildingDatabase currentBuilding, ResourcesStorage resourcesStorage);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}