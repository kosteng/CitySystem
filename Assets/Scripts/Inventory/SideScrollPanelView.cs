using Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class SideScrollPanelView : APanel
    {
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private ToggleGroup _toggleGroup;
        [SerializeField] private TextMeshProUGUI _totalWeight;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        public Transform ScrollParentContent => _scroll.content;
        public ToggleGroup ToggleGroup => _toggleGroup;

        public void SetWeight(float value)
        {
            _totalWeight.text = value.ToString("0.##");
        }

        public void SetDescription(string value)
        {
            _descriptionText.text = value;
        }
    }
}