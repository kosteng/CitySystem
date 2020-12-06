public interface IBuilding
{
    ABuildingView BuildingView { get; }
    ResourcesModel Resources { get; }
    EBuildingType BuildingType { get; }
    void Income();
    void Expense();
}