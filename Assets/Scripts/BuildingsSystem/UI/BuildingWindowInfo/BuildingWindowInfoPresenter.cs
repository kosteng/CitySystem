﻿using BuildingsSystem;
using BuildingsSystem.Enums;
using BuildingsSystem.Interfaces;
using System;
using Engine.UI;
using Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI.BottomPanel
{
    public class BuildingWindowInfoPresenter : IDisposable, IAttachableUi, IInitializable
    {
        private readonly BuildingWindowInfoView _view;
        private readonly IInventoryWindowPresenter _inventoryWindowPresenter;
        private readonly InventoryView _inventoryView;
        
        public BuildingWindowInfoPresenter(BuildingWindowInfoView view, IInventoryWindowPresenter inventoryWindowPresenter)
        {
            _view = view;
            _inventoryWindowPresenter = inventoryWindowPresenter;
        }

        public void Show(IBuilding buildingModel)
        {
            if (EventSystem.current.IsPointerOverGameObject())
              return;
            _view.gameObject.SetActive(true);
            _view.SetName(buildingModel.BuildingType.ToString());
            if (buildingModel.BuildingType == EBuildingType.Storage)
            {
                _view.Hide();
                _inventoryWindowPresenter.ShowChange();
            }
        }
        
        private void Subscribe()
        {
            Hide();
            _view.Subscribe(Hide);
        }
        
        public void Hide()
        {
            _view.gameObject.SetActive(false);
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
            Subscribe();
        }
    }
}
