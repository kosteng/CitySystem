using City;
using Engine.Mediators;
using Engine.UI;
using InputControls;
using Items.ResourceItems;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IResourcesStorage _characterResourcesStorage;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly IResourceItemsTransfer _resourceItemsTransfer;
        private readonly ICityController _cityController;
        
        private readonly List<InventoryCellView> _leftSideCells = new List<InventoryCellView>();
        private readonly List<InventoryCellView> _rightSideCells = new List<InventoryCellView>();
        
        private EInventoryRightSideState _rightSideState;
        
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
            _characterResourcesStorage = characterMovementController.CharacterModel.ResourcesStorage;
            _playerInputControls = playerInputControls;
            _resourceItemsTransfer = resourceItemsTransfer;
            _cityController = cityController;
        }

        public void Show()
        {
            RefreshData();
            _view.Show();
            ShowRightSidePanel();
            _rightSideState = EInventoryRightSideState.Change;
        }
        
        private void InitCells(List<InventoryCellView> sideCells, IResourcesStorage resourcesStorage, Transform parent, EInventoryCellSide side)
        {
            var toggleGroup = side == EInventoryCellSide.LeftSide
                ? _view.LeftSidePanel.ToggleGroup
                : _view.RightSidePanel.ToggleGroup;
            
            foreach (var itemData in resourcesStorage.ResourceItemsData)
            {
                var cell = _inventoryCellBuilder.Build(itemData.ResourceItemType, parent, toggleGroup, side);

                cell.Subscribe(OnCellClick, OnShowTransferWindow);

                sideCells.Add(cell);
            }
        }
        
        public void Initialize()
        {
            _view.Hide();
            _playerInputControls.CheatAddResources(_characterResourcesStorage);

            if (_leftSideCells.Count > 0 && _rightSideCells.Count > 0)
                return;

            _characterResourcesStorage.OnChanced += RefreshData;
            _cityController.ResourcesStorage.OnChanced += RefreshData;

            InitCells(_leftSideCells, _characterResourcesStorage, _view.LeftSidePanel.ScrollParentContent, EInventoryCellSide.LeftSide);
            
            if (_rightSideState == EInventoryRightSideState.Change)
                InitCells(_rightSideCells, _cityController.ResourcesStorage, _view.RightSidePanel.ScrollParentContent, EInventoryCellSide.RightSide);
            
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
                if (_rightSideState == EInventoryRightSideState.Equipment)
                {
                    _resourceItemsTransfer.Transfer(_characterResourcesStorage, type, amount);
                }
                else
                {
                    _resourceItemsTransfer.Transfer(_characterResourcesStorage, _cityController.ResourcesStorage, type, amount);
                }
            }

            if (side == EInventoryCellSide.RightSide)
            {
                _resourceItemsTransfer.Transfer(_cityController.ResourcesStorage, _characterResourcesStorage, type, amount);
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

        private void FillCells(List<InventoryCellView> sideCells, IResourcesStorage resourcesStorage)
        {
            foreach (var cell in sideCells)
            {
                foreach (var itemData in resourcesStorage.ResourceItemsData)
                {
                    if (cell.ItemType != itemData.ResourceItemType)
                        continue;

                    var weight = resourcesStorage.GetResourceWeight(itemData.ResourceItemType);
                    cell.gameObject.SetActive(itemData.Amount > 0);

                    cell.Refresh(itemData.Amount, weight);

                    break;
                }
            }
        }

        private void RefreshData()
        {
            FillCells(_leftSideCells, _characterResourcesStorage);

            _view.LeftSidePanel.SetWeight(_characterResourcesStorage.GetTotalWeight());

            if (_rightSideState == EInventoryRightSideState.Change)
            {
                FillCells(_rightSideCells, _cityController.ResourcesStorage);
                _view.RightSidePanel.SetWeight(_cityController.ResourcesStorage.GetTotalWeight());
            }
        }


//todo удалить если не понадобится
        private void Transfer()
        {
            _resourceItemsTransfer.Transfer(_characterResourcesStorage, _cityController.ResourcesStorage, EResourceItemType.Log,
                13);
        }

        private void ShowCharacterEquipmentPanel()
        {
            _view.RightSidePanel.Hide();
            _view.CharacterInventoryEquipmentView.Show();
        }
        
        private void ShowRightSidePanel()
        {
            _view.RightSidePanel.Show();
            _view.CharacterInventoryEquipmentView.Hide();
            _view.LeftSidePanel.ToggleGroup.ActiveToggles();
        }
        public void Update(float deltaTime)
        {
            if (_playerInputControls.PressInventoryButton())
            {
                if (!_view.gameObject.activeSelf)
                {
                    RefreshData();
                }

                _rightSideState = EInventoryRightSideState.Equipment;
                ShowCharacterEquipmentPanel();
                _view.SwitchActiveState();
                _transferPopupView.Hide();
            }
        }

        private void OnCellClick(bool isOnToggle, InventoryCellView cell, EInventoryCellSide side)
        {
            cell.SetColor(isOnToggle);
        }

        private void OnShowTransferWindow(InventoryCellView cell, EInventoryCellSide side)
        {
            var maxAmount = side == EInventoryCellSide.LeftSide
                ? _characterResourcesStorage.GetAmountResource(cell.ItemType)
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
            _characterResourcesStorage.OnChanced -= RefreshData;
            _cityController.ResourcesStorage.OnChanced -= RefreshData;
        }
    }
}