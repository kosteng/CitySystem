using System.Collections.Generic;
using UnityEngine;

namespace BuildingsSystem.Databases
{
    [CreateAssetMenu(menuName = "DatabasesSO/AllBuildingsDatabase")]
    public class BuildingsModelDatabase : ScriptableObject
    {
        [SerializeField] private List<BuildingDatabase> _buildingsDatabase;
        public List<BuildingDatabase> BuildingsDatabase => _buildingsDatabase;
    }
}