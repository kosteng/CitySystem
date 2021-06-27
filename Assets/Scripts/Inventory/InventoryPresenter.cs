using City;
using Engine.Mediators;
using Engine.UI;
using InputControls;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using Units.Controllers;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public class InventoryPresenter : IAttachableUi, IUpdatable, IInitializable, IDisposable
    {
        private readonly InventoryView _view;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;
        private readonly IResourcesStorage _resourcesStorage;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly IResourceItemsTransfer _resourceItemsTransfer;
        private readonly ICityController _cityController;
        private readonly List<InventoryCellView> _cells = new List<InventoryCellView>();

        public InventoryPresenter(InventoryView view,
            IInventoryCellBuilder inventoryCellBuilder,
            CharacterMovementController characterMovementController,
            IPlayerInputControls playerInputControls,
            IResourceItemsTransfer resourceItemsTransfer,
            ICityController cityController)
        {
            _view = view;
            _inventoryCellBuilder = inventoryCellBuilder;
            _resourcesStorage = characterMovementController.CharacterModel.ResourcesStorage;
            _playerInputControls = playerInputControls;
            _resourceItemsTransfer = resourceItemsTransfer;
            _cityController = cityController;
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        private void RefreshData()
        {
            foreach (var cell in _cells)
            {
                foreach (var resourceItemData in _resourcesStorage.ResourceItemsData)
                {
                    if (cell.ItemType != resourceItemData.ResourceItemType)
                        continue;

                    cell.Amount = resourceItemData.Amount;
                    cell.gameObject.SetActive(cell.Amount > 0);

                    cell.RefreshAmount();

                    break;
                }
            }
        }

        public void Update(float deltaTime)
        {
            _resourceItemsTransfer.Transfer(_resourcesStorage, _cityController.ResourcesStorage, EResourceItemType.Log, 13);

            if (_playerInputControls.PressInventoryButton())
            {
                if (!_view.gameObject.activeSelf)
                {
                    RefreshData();
                }

                _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            }
            
            if (_playerInputControls.UseTransfer())
            {
                Debug.Log(1);
                _resourceItemsTransfer.Transfer(_resourcesStorage, _cityController.ResourcesStorage, EResourceItemType.Log, 10);
            }
            
        }

        private void OnCellClick(bool isOnToggle, InventoryCellView cell)
        {
            cell.SetColor(isOnToggle);
        }

        public void Initialize()
        {
            _playerInputControls.CheatAddResources(_resourcesStorage);
            if (_cells.Count > 0)
                return;
            _resourcesStorage.OnChanced += RefreshData;
            foreach (var itemData in _resourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType, _view.ScrollView, _view.ToggleGroup);
                
                cell.Subscribe(OnCellClick);

                _cells.Add(cell);
            }
        }

        public void Dispose()
        {
            foreach (var inventoryCellView in _cells)
            {
                inventoryCellView.Unsubscribe();
            }
            _resourcesStorage.OnChanced -= RefreshData;
        }
    }
}