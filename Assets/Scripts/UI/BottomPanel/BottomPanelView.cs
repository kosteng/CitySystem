using System;
using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BottomPanel
{
    public class BottomPanelView : APanel
    {
        [SerializeField] private Button _buildingsButton;
        [SerializeField] private Button _inventoryButton;
    
        public void Subscribe(Action onOpenBuildings, Action onOpenInventory)
        {
            _buildingsButton.onClick.AddListener(onOpenBuildings.Invoke);
            _inventoryButton.onClick.AddListener(onOpenInventory.Invoke);
        }
    
        public void Unsubscribe()
        {
            _buildingsButton.onClick.RemoveAllListeners();
            _inventoryButton.onClick.RemoveAllListeners();
        }
    }
}
