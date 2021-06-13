using UnityEngine;
using Zenject;

namespace Items.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/ItemsPrefabsInstaller")]
    public class ItemsPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private InteractItemDatabase _interactItemDatabase;
    
        public override void InstallBindings()
        {
            Container.BindInstance(_interactItemDatabase);
        }
    }
}