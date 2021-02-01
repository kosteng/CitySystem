using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Engine.UI;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.UI.BuildingInfoBuyPanel
{
    public class BuildingInfoBuyPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingBuyPanelView _view;
        private readonly AllBuildingsDatabase _allBuildingsDatabase;
        private readonly BuildingButtonBuilder _buildingButtonBuilder;
        private readonly BuildingsStacker _buildingsStacker;
        private readonly PurchaseBuildingsHandler _purchaseBuildingsHandler;
        private readonly CityDatabase _cityDatabase;
        private List<BuildingButtonView> _buttonsList;
        private BuildingDatabase _currentBuilding;
        
        public List<IBuilding> Buildings = new List<IBuilding>(); //todo этот лист всех зданий скорее всего нужно перенести в контроллер
        public BuildingDatabase CurrentBuild => _currentBuilding;

        public event Action OnBuyBuilding;

        public BuildingInfoBuyPanelPresenter(BuildingBuyPanelView view,
            AllBuildingsDatabase allBuildingsDatabase,
            BuildingButtonBuilder buildingButtonBuilder,
            BuildingsStacker buildingsStacker,
            PurchaseBuildingsHandler purchaseBuildingsHandler,
            CityDatabase cityDatabase)
        {
            _view = view;
            _allBuildingsDatabase = allBuildingsDatabase;
            _buildingButtonBuilder = buildingButtonBuilder;
            _buildingsStacker = buildingsStacker;
            _purchaseBuildingsHandler = purchaseBuildingsHandler;
            _cityDatabase = cityDatabase;
        }

        public void Onckic(ABuildingView buildingView)
        {
            Debug.Log("Delegate " + buildingView.name);
        }
        //TODO рефакторинг зиз
        private void Subscribe()
        {
            _view.OnBuildingClickButton += ShowBuildingData;
            _view.OnBuyBuildingClickButton += BuyBuilding;
            _view.Subscribe(CloseInfoBuyView, CloseInfoBuyView);
            _buildingsStacker.OnBuildingMontage += PurchaseBuilding;

            foreach (var buttons in _buttonsList)
            {
                buttons.Subscribe();
                buttons.OnBuildingClickButton += ShowBuildingData;
            }
            _view.gameObject.SetActive(false);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            _buttonsList = _buildingButtonBuilder.Create(_view.BuildingButtonsPanel);
            Subscribe();
        }

        public void Show()
        {
            _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            _currentBuilding = null;
            // List<string> list = new List<string>();
            // Assembly t = typeof(BuildingController).GetTypeInfo().Assembly;
            // foreach (var a in t.ExportedTypes)
            // {
            //     var count = 0;
            //     foreach (var word in a.ToString().ToCharArray())
            //     {
            //         if (char.IsUpper(word))
            //             count++;
            //         if (count > 3)
            //             list.Add(a.ToString());
            //     }
            //     File.WriteAllLines("e:/list.txt", list);
            // }

        }

        private void CloseInfoBuyView()
        {
            _view.gameObject.SetActive(false);
        }

        private void ShowBuildingData(EBuildingType buildingType)
        {
            foreach (var building in _allBuildingsDatabase.BuildingsDatabase.Where(building =>
                building.BuildingType == buildingType))
            {
                _currentBuilding = building;
                break;
            }

            _view.SetCost(_currentBuilding.ShowCost());
            _view.SetName(buildingType.ToString());
        }

        private ABuildingView _build;
        private void BuyBuilding(EBuildingType buildingType)
        {
            if (_currentBuilding == null)
                return;
            if (!_purchaseBuildingsHandler.TryPurchaseBuilding(_cityDatabase.Model, _currentBuilding.CostResources))
                return;

            _build = MonoBehaviour.Instantiate(_currentBuilding.View);
            _buildingsStacker.StartPlacingBuilding(_build);
        }

        private void PurchaseBuilding()
        {
            _purchaseBuildingsHandler.PurchaseBuilding(_cityDatabase.Model, _currentBuilding.CostResources);
            Create();
            OnBuyBuilding?.Invoke();
        }

        private void Create()
        {
            var building =  new ABuildingModel(null, null, null);
            switch (_currentBuilding.BuildingType)
            {
                case EBuildingType.House:
                    building = new HouseBuildingModel(_build, _currentBuilding.IncomeResources,
                        _cityDatabase);
                    building.Subscribe();
                    building.OnBuildingClickHandler += Onckic;
                    Buildings.Add(building);
                    break;

                case EBuildingType.SawMill:
                    building = new SawBuildingModel(_build, _currentBuilding.IncomeResources,
                        _cityDatabase);
                    building.Subscribe();
                    building.OnBuildingClickHandler += Onckic;
                    Buildings.Add(building);
                    break;

                case EBuildingType.Mine:
                    building = new MineBuildingModel(_build, _currentBuilding.IncomeResources,
                        _cityDatabase);
                    building.Subscribe();
                    building.OnBuildingClickHandler += Onckic;
                    Buildings.Add(building);
                    break;

                default: Debug.LogError($"Unkwown type {_currentBuilding.BuildingType}");
                    break;
            }
        }

        public void Dispose()
        {
            _view.Unsubscribe();
            _view.OnBuildingClickButton -= ShowBuildingData;
            _view.OnBuyBuildingClickButton -= BuyBuilding;
            _buildingsStacker.OnBuildingMontage -= PurchaseBuilding;

            foreach (var buttons in _buttonsList)
            {
                buttons.Unsubscribe();
                buttons.OnBuildingClickButton -= ShowBuildingData;
            }
        }
    }
}