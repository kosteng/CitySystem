using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName ="DatabasesSO/AllBuildingsDatabase")]
    public class AllBuildingsDatabase : ScriptableObject
    {
        public HouseBuildingDatabase HouseBuildingDatabase;
        [SerializeField] private List<BuildingDatabase> _buildingsDatabase;
        public List<BuildingDatabase> BuildingsDatabase => _buildingsDatabase;
    }

[Serializable]
public class BuildingDatabase
{
  [SerializeField] private EBuildingType _buildingType;
  [SerializeField] private string _name;
  [SerializeField] private BuildingView _view;

  public EBuildingType BuildingType => _buildingType;
}