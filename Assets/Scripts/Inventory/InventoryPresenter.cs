using City;
using Engine.Mediators;
using Engine.UI;
using InputControls;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Units.Controllers;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public interface IInventoryPresenter
    {
        void Show();
    }

    public class InventoryPresenter : IInventoryPresenter, IAttachableUi, IUpdatable, IInitializable, IDisposable
    {
        private readonly InventoryView _view;
        private readonly TransferPopupView _transferPopupView;
        private readonly IInventoryCellBuilder _inventoryCellBuilder;
        private readonly IResourcesStorage _resourcesStorage;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly IResourceItemsTransfer _resourceItemsTransfer;
        private readonly ICityController _cityController;
        private readonly List<InventoryCellView> _leftSideCells = new List<InventoryCellView>();
        private readonly List<InventoryCellView> _rightSideCells = new List<InventoryCellView>();

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

        public void Show()
        {
            RefreshData();
            _view.Show();
        }

        public void Initialize()
        {
            _view.Hide();
            _playerInputControls.CheatAddResources(_resourcesStorage);
            
            if (_leftSideCells.Count > 0 && _rightSideCells.Count > 0)
                return;
            
            _resourcesStorage.OnChanced += RefreshData;
            _cityController.ResourcesStorage.OnChanced += RefreshData;
            
            foreach (var itemData in _cityController.ResourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType, _view.RightSideScroll,
                    _view.RightSideToggleGroup, EInventoryCellSide.RightSide);
            
                cell.Subscribe(OnCellClick, OnShowTransferWindow);
            
                _rightSideCells.Add(cell);
            }

            foreach (var itemData in _resourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType, _view.LeftSideScroll,
                    _view.LeftSideToggleGroup, EInventoryCellSide.LeftSide);

                cell.Subscribe(OnCellClick, OnShowTransferWindow);

                _leftSideCells.Add(cell);
            }

            _transferPopupView.Subscribe(OnCancelClick, OnConfirmClick, OnTransferSliderChanced);
        }

        private void OnCancelClick()
        {
            _transferPopupView.Hide();
        }

        private void OnConfirmClick(EResourceItemType type, float amount, EInventoryCellSide side)
        {
            if (side == EInventoryCellSide.LeftSide)
            {
                _resourceItemsTransfer.Transfer(_resourcesStorage, _cityController.ResourcesStorage, type, amount);
            }
            
            else
            {
                _resourceItemsTransfer.Transfer(_cityController.ResourcesStorage,_resourcesStorage, type, amount);
            }
            
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
            foreach (var cell in _leftSideCells)
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

            foreach (var cell in _rightSideCells)
            {
                foreach (var resourceItemData in _cityController.ResourcesStorage.ResourceItemsData)
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
                _view.SwitchActiveState();
                //   _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            }
        }

        private void OnCellClick(bool isOnToggle, InventoryCellView cell, EInventoryCellSide side)
        {
            cell.SetColor(isOnToggle);
        }

        private void OnShowTransferWindow(InventoryCellView cell, EInventoryCellSide side)
        {
            var maxAmount = side == EInventoryCellSide.LeftSide
                ? _resourcesStorage.GetAmountResource(cell.ItemType)
                : _cityController.ResourcesStorage.GetAmountResource(cell.ItemType);
            
            _transferPopupView.Show(cell, maxAmount);
        }

        public void Dispose()
        {
            foreach (var inventoryCellView in _leftSideCells)
            {
                inventoryCellView.Unsubscribe();
            }

            foreach (var inventoryCellView in _rightSideCells)
            {
                inventoryCellView.Unsubscribe();
            }
            _transferPopupView.UnSubscribe();
            _resourcesStorage.OnChanced -= RefreshData;
            _cityController.ResourcesStorage.OnChanced -= RefreshData;
        }
    }
}