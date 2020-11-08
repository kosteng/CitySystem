using BuildingsSystem.UI.BuildingInfoBuyPanel;
using UI.BottomPanel;
using UnityEngine;
using Zenject;

public class BuildingsInstaller : MonoInstaller
{
   [SerializeField] private BuildingBuyPanel _buildingBuyPanel;
   [SerializeField] private BottomPanelView _bottomPanelView;
   [SerializeField] private BuildingFactory _buildingFactory;
   public override void InstallBindings()
   {
      Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
      Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
      Container.BindInstance(_buildingBuyPanel);
      Container.BindInstance(_bottomPanelView);
      Container.BindInstance(_buildingFactory);
   }
}
