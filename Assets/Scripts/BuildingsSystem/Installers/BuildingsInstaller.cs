using BuildingsSystem.UI.BuildingInfoBuyPanel;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.Installers
{
    public class BuildingsInstaller : MonoInstaller
    {
        //     [SerializeField] private BuildingFactory _buildingFactory;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingButtonBuilder>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingsStacker>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<Pool<ABuildingView>>().AsSingle();
        }
    }
}