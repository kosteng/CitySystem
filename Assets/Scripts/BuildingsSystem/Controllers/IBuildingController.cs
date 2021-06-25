using BuildingsSystem.Interfaces;

namespace BuildingsSystem.Controllers
{
    public interface IBuildingController
    {
        void AddBuildings(IBuilding building);
    }
}