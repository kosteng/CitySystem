using System.Collections;
using System.Collections.Generic;
using Building;
using Building.UI.BuildingInfoBuyPanel;
using UnityEngine;
using Zenject;

public class BuildingsInstaller : MonoInstaller
{
   [SerializeField] private BuildingUIInfoBuyView _buildingUiInfoBuyView;
   [SerializeField] private BottomPanelView _bottomPanelView;
   [SerializeField] private BuildingFactory _buildingFactory;
   public override void InstallBindings()
   {
      Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<BuildingInfoBuyPanelPresenter>().AsSingle();
      Container.BindInterfacesAndSelfTo<BottomPanelPresenter>().AsSingle();
      Container.BindInstance(_buildingUiInfoBuyView);
      Container.BindInstance(_bottomPanelView);
      Container.BindInstance(_buildingFactory);
   }
}
