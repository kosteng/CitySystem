using UnityEngine;
using Zenject;

namespace BuildingsSystem.Installers
{
   [CreateAssetMenu(menuName = "DatabasesSO/BuildingsPrefabInstaller")]
   public class BuildingsPrefabInstaller : ScriptableObjectInstaller
   {
      [SerializeField] private HouseBuildingView _house;
      [SerializeField] private AllBuildingsDatabase _allBuildingsDatabase;
      [SerializeField] private HouseBuildingDatabase _houseBuildingDatabase;
      [SerializeField] private Building _building;
      public override void InstallBindings()
      {
         Container.BindInstance(_house);
         Container.BindInstance(_allBuildingsDatabase);
         Container.BindInstance(_houseBuildingDatabase);
         Container.BindInstance(_building);
      }
   }
}