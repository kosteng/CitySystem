using Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class SideScrollPanelView : APanel
    {
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private ToggleGroup toggleGroup;
        [SerializeField] private TextMeshProUGUI _totalWeight;

        public Transform ScrollParentContent => _scroll.content;
        public ToggleGroup ToggleGroup => toggleGroup;

        public void SetWeight(float value)
        {
            _totalWeight.text = value.ToString("0.##");
        }
    }
}