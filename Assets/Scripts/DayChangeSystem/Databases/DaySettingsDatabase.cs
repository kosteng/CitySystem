using UnityEngine;

namespace DayChangeSystem.Databases
{
    [CreateAssetMenu(menuName = "DatabasesSO/DaySettingsDatabase")]
    public class DaySettingsDatabase : ScriptableObject
    {
    
        public int DayLength; 
        public int HourLength;
    }
}
