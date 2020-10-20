using Building;
using Building.BuildingsData;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "DatabasesSO/BuildingsPrefabInstaller")]
public class BuildingsPrefabInstaller : ScriptableObjectInstaller
{
   [SerializeField] private DayCounterView _dayCounterView;
   [SerializeField] private DayCountDatabase _dayCounterDataBase;
   [SerializeField] private HouseBuildingView _house;
   [SerializeField] private CityDatabase _cityDatabase;
   [SerializeField] private AllBuildingsDatabase _allBuildingsDatabase;
   [SerializeField] private HouseBuildingDatabase _houseBuildingDatabase;

   public override void InstallBindings()
   {
      Container.BindInstance(_house);
      Container.BindInstance(_dayCounterDataBase);
      Container.BindInstance(_cityDatabase);
      
      Container.BindInstance(_allBuildingsDatabase);
      Container.BindInstance(_houseBuildingDatabase);
   }
}