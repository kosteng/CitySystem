using System;
using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BottomPanel
{
    public class BottomPanelView : APanel
    {
        [SerializeField] private Button _buildingsButton;
    
        public void Subscribe(Action onOpen)
        {
            _buildingsButton.onClick.AddListener(onOpen.Invoke);
        }
    
        public void Unsubscribe()
        {
            _buildingsButton.onClick.RemoveAllListeners();
        }
    }
}
