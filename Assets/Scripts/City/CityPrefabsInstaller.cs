using UnityEngine;
using Zenject;

namespace City
{
    [CreateAssetMenu(menuName = "DatabasesSO/CityPrefabsInstaller")]
    public class CityPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CityDatabase _cityDatabase;

        public override void InstallBindings()
        {
            Container.BindInstance(_cityDatabase);
        }
    }
}