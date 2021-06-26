using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DayChangeSystem.Views
{
    public class DayCounterView : APanel
    {
        [SerializeField] private Text _dayText;
        [SerializeField] private Text _seasonText;
        [SerializeField] private Text _hourText;

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