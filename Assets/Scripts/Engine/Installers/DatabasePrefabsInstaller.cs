using BuildingsSystem.Databases;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using City;
using DayChangeSystem.Databases;
using DayChangeSystem.Views;
using Inventory;
using Items.InteractItems;
using Items.ResourceItems;
using Units.Views;
using UnityEngine;
using Zenject;

namespace Engine.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/Installers/DatabasePrefabsInstaller")]
    public class DatabasePrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BuildingsModelDatabase _buildingsModelDatabase;
        [SerializeField] private CityDatabase _cityDatabase;
        [SerializeField] private DaySettingsDatabase _dayCounterDataBase;
        [SerializeField] private InteractItemsDatabase _interactItemsDatabase;
        [SerializeField] private ResourceItemsDatabase _resourceItemsDatabase;
        [SerializeField] private CharactersDatabase _charactersDatabase;
        
        [SerializeField] private BuildingButtonView _buildingButtonView;
        [SerializeField] private CharacterView _player;
        [SerializeField] private SunView _sun;
        [SerializeField] private GameObject _moon;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private InventoryCellView _inventoryCell;
        public override void InstallBindings()
        {
            Buildings();
            City();
            DayChangeSystem();
            Inputs();
            Inventory();
            Items();
            Characters();
        }

        private void Buildings()
        {
            Container.BindInstance(_buildingsModelDatabase);
            Container.BindInstance(_buildingButtonView);
        }

        private void City()
        {
            Container.BindInstance(_cityDatabase);
        }

        private void DayChangeSystem()
        {
            Container.BindInstance(_dayCounterDataBase);
            Container.BindInstance(_sun);
            Container.BindInstance(_moon);
        }

        private void Inputs()
        {
            Container.BindInstance(_cameraView);
        }

        private void Inventory()
        {
            Container.BindInstance(_inventoryCell);
        }

        private void Items()
        {
            Container.BindInstance(_interactItemsDatabase);
            Container.BindInstance(_resourceItemsDatabase);
        }

        private void Characters()
        {
            Container.BindInstance(_player);
            Container.BindInstance(_charactersDatabase);
        }
    }
}