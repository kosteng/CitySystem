
using DayChangeSystem.Databases;
using DayChangeSystem.Views;
using UnityEngine;
using Zenject;

namespace DayChangeSystem.Installers
{
   [CreateAssetMenu(menuName = "DatabasesSO/BuildingsPrefabInstaller")]
   public class BuildingsPrefabInstaller : ScriptableObjectInstaller
   {
      [SerializeField] private DayCounterView _dayCounterView;
      [SerializeField] private DaySettingsDatabase _dayCounterDataBase;
      [SerializeField] private HouseBuildingView _house;
      [SerializeField] private CityDatabase _cityDatabase;
      [SerializeField] private AllBuildingsDatabase _allBuildingsDatabase;
      [SerializeField] private HouseBuildingDatabase _houseBuildingDatabase;
      [SerializeField] private SunView _sun;
      [SerializeField] private GameObject _moon;
      [SerializeField] private Building _building;
      public override void InstallBindings()
      {
         Container.BindInstance(_house);
         Container.BindInstance(_dayCounterDataBase);
         Container.BindInstance(_cityDatabase);
         Container.BindInstance(_allBuildingsDatabase);
         Container.BindInstance(_houseBuildingDatabase);
         Container.BindInstance(_sun);
         Container.BindInstance(_moon);
         Container.BindInstance(_building);
      }
   }
}