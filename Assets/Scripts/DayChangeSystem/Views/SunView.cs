using DayChangeSystem.Databases;
using UnityEngine;


namespace DayChangeSystem.Views
{
    public class SunView : MonoBehaviour
    {
        [SerializeField] private Light _sun;
        private float _timeOfDay;
        
        public void ChangeDayOfNight(DaySettingsDatabase daySettingsDatabase)
        {
            int day = daySettingsDatabase.DayLength * daySettingsDatabase.HourLength;
            _timeOfDay += Time.deltaTime / day;
          //  if (_timeOfDay >= 360) _timeOfDay = 0;

            _sun.transform.localRotation = Quaternion.Euler(_timeOfDay * 360, 180, 0);
        }
    }
}