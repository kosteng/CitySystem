using BuildingsSystem.Views;

namespace BuildingsSystem
{
    public delegate void BuildingMontageHandler(ABuildingView building);
    public interface IBuildingsStacker
    {
        event BuildingMontageHandler OnBuildingMontage;
        void StartPlacingBuilding(ABuildingView buildingPrefab);
    }
}