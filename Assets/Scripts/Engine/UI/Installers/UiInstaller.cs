using BuildingsSystem.UI.BuildingInfoBuyPanel;
using DayChangeSystem;
using DayChangeSystem.Controllers;
using DayChangeSystem.Models;
using Engine.Mediators;
using Engine.UI.Canvas;
using UI.BottomPanel;
using Zenject;
namespace Engine.UI.Installers
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CanvasContainer>().AsSingle();
            Container.BindInterfacesTo<UiAttachSystem.UiAttachSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<CityController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HourController>().AsSingle();

            Container.BindInterfacesTo<DayModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SunPrefabFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
        }
    }
}
    