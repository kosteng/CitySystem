using System;
using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BottomPanel
{
    public class BuildingWindowInfoView : APanel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Text _nameText;
        public void Subscribe(Action onHide)
        {
            _closeButton.onClick.AddListener(onHide.Invoke);
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }
        public void Unsubscribe()
        {
            _closeButton.onClick.RemoveAllListeners();
        }

    }
}