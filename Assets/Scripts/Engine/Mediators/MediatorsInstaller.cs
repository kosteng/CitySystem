using Zenject;

namespace Engine.Mediators
{
    public class MediatorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityEventMediator>().AsSingle().NonLazy();
        }
    }
}