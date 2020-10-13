using System.Collections.Generic;
using UnityEngine;

namespace Building.BuildingsData
{
    [CreateAssetMenu(menuName ="DatabasesSO/AllBuildingsDatabase")]
    public class AllBuildingsDatabase : ScriptableObject
    {
        public HouseBuildingDatabase HouseBuildingDatabase;
    }
}
