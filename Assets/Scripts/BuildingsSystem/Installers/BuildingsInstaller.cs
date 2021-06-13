using BuildingsSystem.Controllers;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using Extensions.Pool;
using UI.BottomPanel;
using Zenject;

namespace BuildingsSystem.Installers
{
    public class BuildingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingButtonBuilder>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingsStacker>().AsSingle();
            Container.BindInterfacesAndSelfTo<Pool<ABuildingView>>().AsSingle();
            Container.BindInterfacesAndSelfTo<PurchaseBuildingsHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingWindowInfoPresenter>().AsSingle();
            Container.BindInterfacesTo<BuildingFactory>().AsSingle();
        }
    }
}