using BuildingsSystem.UI.BuildingInfoBuyPanel;
using City;
using UI.BottomPanel;
using UnityEngine;
using Zenject;

namespace Engine.UI.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/UIPrefabsInstaller")]
    public class UIPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CanvasView _canvasView;
        [SerializeField] private BottomPanelView _bottomPanelView;
        [SerializeField] private BuildingBuyPanelView _buildingBuyPanelView;
        [SerializeField] private CityView _cityView;
        [SerializeField] private DayCounterView _dayCounterView;
        [SerializeField] private BuildingWindowInfoView _buildingWindowInfoView;

        public override void InstallBindings()
        {
            Container.Bind<CanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();
            Container.Bind<BottomPanelView>().FromComponentInNewPrefab(_bottomPanelView).AsSingle();
            Container.Bind<BuildingBuyPanelView>().FromComponentInNewPrefab(_buildingBuyPanelView).AsSingle();
            Container.Bind<CityView>().FromComponentInNewPrefab(_cityView).AsSingle();
            Container.Bind<DayCounterView>().FromComponentInNewPrefab(_dayCounterView).AsSingle();
            Container.Bind<BuildingWindowInfoView>().FromComponentInNewPrefab(_buildingWindowInfoView).AsSingle();
        }
    }
}