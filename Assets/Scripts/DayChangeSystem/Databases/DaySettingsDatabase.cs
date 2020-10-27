using UnityEngine;
using UnityEngine.Serialization;

namespace DayChangeSystem.Databases
{
    [CreateAssetMenu(menuName = "DatabasesSO/DaySettingsDatabase")]
    public class DaySettingsDatabase : ScriptableObject
    {
        [SerializeField] private int _dayLength;
        [SerializeField] private int _hourLength;
        [SerializeField] private int _daysInSeason;
        public int DayLength => _dayLength; 
        public int HourLength => _hourLength;
        public int DaysInSeason => _daysInSeason;
    }
}
