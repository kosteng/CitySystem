using UnityEngine;

public class MonoBehaviourConteiner : MonoBehaviour
{
    // prefabs
    public DayCounterView DayCounterView;
    public CityView CityView;
    public BuildingView SawMill;
    public BuildingView Mine;
    public BuildingView House;
    public BuildingUIView BuildingUIView;
    public BottomPanalView BottomPanalView;

    //Factories


    // Databases
    public DayCountDatabase DayCounterDataBase;
    public CityDatabase CityDatabase;
    public AllBuildingsDatabase AllBuildingsDatabase;

}
