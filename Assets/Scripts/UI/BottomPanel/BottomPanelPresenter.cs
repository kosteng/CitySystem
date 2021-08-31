using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using Engine.UI;
using Inventory;
using UnityEngine;
using Zenject;

namespace UI.BottomPanel
{
    public class BottomPanelPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BottomPanelView _view;
        private readonly BuildingPurchaseWindowPresenter _buildingPurchaseWindowPresenter;
        private readonly IInventoryWindowPresenter _inventoryWindowPresenter;

        public BottomPanelPresenter(BottomPanelView view, BuildingPurchaseWindowPresenter buildingPurchaseWindowPresenter, IInventoryWindowPresenter inventoryWindowPresenter)
        {
            _view = view;
            _buildingPurchaseWindowPresenter = buildingPurchaseWindowPresenter;
            _inventoryWindowPresenter = inventoryWindowPresenter;
        }

        private void OnShowBuildingsPurchaseWindow()
        {
            _buildingPurchaseWindowPresenter.Show();
        }

        private void OnShowInventoryWindow()
        {
            _inventoryWindowPresenter.ShowCharacterInventory();
        }
        
        public void Dispose()
        {
            _view.Unsubscribe();
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }

        public void Initialize()
        {
            _view.Subscribe(OnShowBuildingsPurchaseWindow, OnShowInventoryWindow);
        }
    }
}