public delegate void BuildingClickHandler(ABuildingView building);
public interface IBuilding
{
    void Subscribe();
    ABuildingView BuildingView { get; }
    ResourcesModel Resources { get; }
    EBuildingType BuildingType { get; }
    void Income();
    void Expense();
    event BuildingClickHandler OnBuildingClickHandler;
}