using Units.Controllers;
using Zenject;

namespace Units.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterMovementController>().AsSingle();
            Container.BindInterfacesTo<CharacterAnimationSwitcher>().AsSingle();
        }
    }
}
