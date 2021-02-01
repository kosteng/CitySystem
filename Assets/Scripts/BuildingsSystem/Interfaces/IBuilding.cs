public delegate void BuildingClickHandler(ABuildingView building);
public interface IBuilding
{
    
    ABuildingView BuildingView { get; }
    ResourcesModel Resources { get; }
    EBuildingType BuildingType { get; }
    void Income();
    void Expense();
    event BuildingClickHandler OnBuildingClickHandler;
}