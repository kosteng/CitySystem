using BuildingsSystem;
using BuildingsSystem.Controllers;
using BuildingsSystem.UI;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using BuildingsSystem.Views;
using Characters.Controllers;
using City;
using DayChangeSystem;
using DayChangeSystem.Controllers;
using DayChangeSystem.Models;
using Engine.Mediators;
using Engine.UI.Canvas;
using Extensions.Pool;
using InputControls;
using InputControls.CameraControls;
using InputControls.InpitClicker;
using Inventory;
using Items.ResourceItems;
using UI.BottomPanel;
using Units.Controllers;
using Zenject;

namespace Engine.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BuildingsSystem();
            CitySystem();
            Characters();
            DaySystem();
            
            Mediators();
            InputControls();
            InventorySystem();
            Items();
            Ui();
        }

        private void BuildingsSystem()
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

        private void CitySystem()
        {
            Container.BindInterfacesAndSelfTo<CityController>().AsSingle();
        }
        
        private void Characters()
        {
            Container.BindInterfacesAndSelfTo<CharacterMovementController>().AsSingle();
            Container.BindInterfacesTo<CharacterAnimationSwitcher>().AsSingle();
            Container.BindInterfacesTo<CharacterItemExtractor>().AsSingle();
        }
        
        private void DaySystem()
        {
            Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle();
            Container.BindInterfacesAndSelfTo<HourController>().AsSingle();
            Container.BindInterfacesAndSelfTo<DayCounterPresenter>().AsSingle();
            Container.BindInterfacesTo<DayModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SunPrefabFactory>().AsSingle();
        }
        
        private void Mediators()
        {
            Container.BindInterfacesTo<UnityEventMediator>().AsSingle().NonLazy();
        }
        
        private void InputControls()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesTo<InputClicker>().AsSingle();
            Container.BindInterfacesTo<PlayerInputControls>().AsSingle();
        }
        
        private void InventorySystem()
        {
            Container.BindInterfacesTo<InventoryPresenter>().AsSingle();
            Container.BindInterfacesTo<InventoryCellFactory>().AsSingle();
            Container.BindInterfacesTo<InventoryCellBuilder>().AsSingle();
        }
        
        private void Items()
        {
            Container.BindInterfacesAndSelfTo<Items.InteractableItemController>().AsSingle();
            Container.BindInterfacesTo<Items.InteractItemFactory>().AsSingle();
            Container.BindInterfacesTo<ResourceItemsTransfer>().AsSingle();
        }

        private void Ui()
        {
            Container.BindInterfacesTo<CanvasContainer>().AsSingle();
            Container.BindInterfacesTo<UI.UiAttachSystem.UiAttachSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
        }
    }
}
