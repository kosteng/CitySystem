using Engine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DayChangeSystem.Views
{
    public class DayCounterView : APanel
    {
        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private TextMeshProUGUI _seasonText;
        [SerializeField] private TextMeshProUGUI _hourText;

        public void SetHour(string value)
        {
            _hourText.text = value;
        }

        public void SetDay(string value)
        {
            _dayText.text = value;
        }

        public void SetSeason(string value)
        {
            _seasonText.text = value;
        }
    }
}