using System.Collections.Generic;
using Building;
using Building.BuildingsData;
using Building.UI.BuildingInfoBuyPanel;
using UnityEngine;
using UnityEngine.Serialization;


namespace Architecture
{
    public class MonoBehaviourConteiner : MonoBehaviour
    {
        // prefabs
        public DayCounterView DayCounterView;
        public CityView CityView;

        public HouseBuildingView HouseBuildingView;
        public BuildingUIInfoBuyView BuildingUIView;
        public BottomPanelView BottomPanelView;
        public List<GameObject> AllBuildingsView;

        //Factories
        public BuildingFactory BuildingFactory;

        // Databases
        public DayCountDatabase DayCounterDataBase;
        public CityDatabase CityDatabase;
        public AllBuildingsDatabase AllBuildingsDatabase;

    }
}
