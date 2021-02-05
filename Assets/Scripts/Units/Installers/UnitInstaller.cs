using Units.Controllers;
using Zenject;

namespace Units.Installers
{
    public class UnitInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle();
        }
    }
}
