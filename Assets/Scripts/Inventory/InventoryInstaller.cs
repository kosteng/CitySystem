using Zenject;

namespace Inventory
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InventoryPresenter>().AsSingle();
        }
    }
}
