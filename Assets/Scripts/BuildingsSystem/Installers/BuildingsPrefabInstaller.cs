using UI.BottomPanel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BuildingsSystem.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/BuildingsPrefabInstaller")]
    public class BuildingsPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AllBuildingsDatabase _allBuildingsDatabase;
        [SerializeField] private Button _buildingButtonInPanel;
        [SerializeField] private BuildingButtonView _buildingButtonView;
 
        public override void InstallBindings()
        {
            Container.BindInstance(_allBuildingsDatabase);
            Container.BindInstance(_buildingButtonInPanel);
            Container.BindInstance(_buildingButtonView);
        }
    }
}