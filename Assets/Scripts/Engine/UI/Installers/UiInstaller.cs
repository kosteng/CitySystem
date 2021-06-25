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
            Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
        }
    }
}
    