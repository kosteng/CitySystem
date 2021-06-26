using BuildingsSystem.UI.BuildingInfoBuyPanel;
using City;
using DayChangeSystem.Views;
using Engine.UI;
using Inventory;
using UI.BottomPanel;
using UnityEngine;
using Zenject;

namespace Engine.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/Installers/UiPrefabsInstaller")]
    public class UiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CanvasView _canvasView;
        [SerializeField] private BottomPanelView _bottomPanelView;
        [SerializeField] private BuildingBuyPanelView _buildingBuyPanelView;
        [SerializeField] private CityView _cityView;
        [SerializeField] private DayCounterView _dayCounterView;
        [SerializeField] private BuildingWindowInfoView _buildingWindowInfoView;
        [SerializeField] private InventoryView _inventoryView;
        public override void InstallBindings()
        {
            Container.Bind<CanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();
            Container.Bind<BottomPanelView>().FromComponentInNewPrefab(_bottomPanelView).AsSingle();
            Container.Bind<BuildingBuyPanelView>().FromComponentInNewPrefab(_buildingBuyPanelView).AsSingle();
            Container.Bind<CityView>().FromComponentInNewPrefab(_cityView).AsSingle();
            Container.Bind<DayCounterView>().FromComponentInNewPrefab(_dayCounterView).AsSingle();
            Container.Bind<BuildingWindowInfoView>().FromComponentInNewPrefab(_buildingWindowInfoView).AsSingle();
            Container.Bind<InventoryView>().FromComponentInNewPrefab(_inventoryView).AsSingle();
        }
    }
}