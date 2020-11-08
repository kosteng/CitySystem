using DayChangeSystem.Views;
using UnityEngine;

namespace DayChangeSystem
{
    public class SunPrefabFactory
    {
        public SunView Create(SunView prefab)
        {
            return MonoBehaviour.Instantiate(prefab);
        }
    }
}