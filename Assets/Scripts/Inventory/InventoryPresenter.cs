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
        private readonly TransferPopupView _transferPopupView;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;
        private readonly IResourcesStorage _resourcesStorage;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly IResourceItemsTransfer _resourceItemsTransfer;
        private readonly ICityController _cityController;
        private readonly List<InventoryCellView> _cells = new List<InventoryCellView>();

        public InventoryPresenter(InventoryView view,
            TransferPopupView transferPopupView,
            IInventoryCellBuilder inventoryCellBuilder,
            CharacterMovementController characterMovementController,
            IPlayerInputControls playerInputControls,
            IResourceItemsTransfer resourceItemsTransfer,
            ICityController cityController)
        {
            _view = view;
            _transferPopupView = transferPopupView;
            _inventoryCellBuilder = inventoryCellBuilder;
            _resourcesStorage = characterMovementController.CharacterModel.ResourcesStorage;
            _playerInputControls = playerInputControls;
            _resourceItemsTransfer = resourceItemsTransfer;
            _cityController = cityController;
        }

        public void Initialize()
        {
            _view.gameObject.SetActive(false);
            _playerInputControls.CheatAddResources(_resourcesStorage);
            if (_cells.Count > 0)
                return;
            _resourcesStorage.OnChanced += RefreshData;

            foreach (var itemData in _resourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType, _view.ScrollView, _view.ToggleGroup);

                cell.Subscribe(OnCellClick, OnShowTransferWindow);

                _cells.Add(cell);
            }

            _transferPopupView.Subscribe(OnCancelClick, OnConfirmClick, OnTransferSliderChanced);
        }

        private void OnCancelClick()
        {
            _transferPopupView.Hide();
        }

        private void OnConfirmClick(EResourceItemType type, float amount)
        {
            _resourceItemsTransfer.Transfer(_resourcesStorage, _cityController.ResourcesStorage, type, amount);
            _transferPopupView.Hide();
        }

        private void OnTransferSliderChanced(float value)
        {
            _transferPopupView.SetCurrentAmount(value);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
            _transferPopupView.Attach(parent);
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

//todo удалить если не понадобится
        private void Transfer()
        {
            _resourceItemsTransfer.Transfer(_resourcesStorage, _cityController.ResourcesStorage, EResourceItemType.Log,
                13);
        }

        public void Update(float deltaTime)
        {
            if (_playerInputControls.PressInventoryButton())
            {
                if (!_view.gameObject.activeSelf)
                {
                    RefreshData();
                }

                _transferPopupView.Hide();
                _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            }
        }

        private void OnCellClick(bool isOnToggle, InventoryCellView cell)
        {
            cell.SetColor(isOnToggle);
        }

        private void OnShowTransferWindow(InventoryCellView cell)
        {
            var maxAmount = _resourcesStorage.GetAmountResource(cell.ItemType);
            _transferPopupView.Show(cell.ItemType, maxAmount);
        }

        public void Dispose()
        {
            foreach (var inventoryCellView in _cells)
            {
                inventoryCellView.Unsubscribe();
            }

            _transferPopupView.UnSubscribe();
            _resourcesStorage.OnChanced -= RefreshData;
        }
    }
}