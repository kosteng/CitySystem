public interface IBuilding
{
    ABuildingView BuildingView { get; }
    ResourcesesModel Resourceses { get; }

    void Income();
}