namespace BuildingsSystem
{
    public interface IBuildingFactory
    {
        IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityDatabase cityDatabase);
        ABuildingView Create(ABuildingView montageBuilding);
    }
}