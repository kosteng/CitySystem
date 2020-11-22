using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField] private Button _buildingButtonInPanel;
        [SerializeField] private BuildingButtonView _buildingButtonView;

        public override void InstallBindings()
        {
            Container.BindInstance(_house);
            Container.BindInstance(_allBuildingsDatabase);
            Container.BindInstance(_houseBuildingDatabase);
            Container.BindInstance(_building);
            Container.BindInstance(_buildingButtonInPanel);
            Container.BindInstance(_buildingButtonView);
        }
    }
}