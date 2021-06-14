using Zenject;

namespace City
{
    public class CityInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CityController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CityModel>().AsSingle();
        }
    }
}
