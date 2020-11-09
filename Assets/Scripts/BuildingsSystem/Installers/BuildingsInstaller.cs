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
            // Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle().NonLazy();
     //       Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
        }
    }
}
