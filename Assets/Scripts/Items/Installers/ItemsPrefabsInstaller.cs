using Items.ResourceItems;
using UnityEngine;
using Zenject;

namespace Items.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/ItemsPrefabsInstaller")]
    public class ItemsPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private InteractItemsDatabase _interactItemsDatabase;
        [SerializeField] private ResourceItemsDatabase _resourceItemsDatabase;
    
        public override void InstallBindings()
        {
            Container.BindInstance(_interactItemsDatabase);
            Container.BindInstance(_resourceItemsDatabase);
        }
    }
}