using BuildingsSystem.Databases;
using BuildingsSystem.Interfaces;
using BuildingsSystem.Views;
using City;
using Items.ResourceItems;

namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(ABuildingView view, BuildingDatabase currentBuilding, IResourcesStorage resourcesStorage);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}