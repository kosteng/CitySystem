using System;
using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BottomPanel
{
    public class BuildingWindowInfoView : APanel
    {
        [SerializeField] private Button _closeButton;
    
        public void Subscribe(Action onHide)
        {
            _closeButton.onClick.AddListener(onHide.Invoke);
        }
    
        public void Unsubscribe()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}