using BuildingsSystem;
using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;

public delegate void BuildingClickHandler(ABuildingModel building); //todo скорее всего нужно переделать
public interface IBuilding
{
    void Subscribe();
    ABuildingView BuildingView { get; }
 //   ResourcesModel Resources { get; }
    EBuildingType BuildingType { get; }
    void Income();
    void Expense();
    event BuildingClickHandler OnBuildingClickHandler;
}