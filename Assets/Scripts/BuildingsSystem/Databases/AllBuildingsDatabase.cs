using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName ="DatabasesSO/AllBuildingsDatabase")]
    public class AllBuildingsDatabase : ScriptableObject
    {
        public HouseBuildingDatabase HouseBuildingDatabase;
        [SerializeField] private List<ABuildingDatabase> _buildingDatabases;
        public List<ABuildingDatabase> BuildingDatabases => _buildingDatabases;
    }
[Serializable]
public class ABuildingDatabase
{
  [SerializeField] private EBuildingType _buildingType;
  [SerializeField] private string _name;
  [SerializeField] private ABuildingView _view;
}