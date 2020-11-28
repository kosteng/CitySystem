using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(menuName ="DatabasesSO/AllBuildingsDatabase")]
    public class AllBuildingsDatabase : ScriptableObject
    {
        [SerializeField] private List<BuildingDatabase> _buildingsDatabase;
        public List<BuildingDatabase> BuildingsDatabase => _buildingsDatabase;
    }

[Serializable]
public class BuildingDatabase
{
  [SerializeField] private EBuildingType _buildingType;
  [SerializeField] private string _name;
  [SerializeField] private ABuildingView _view;
  [SerializeField] private ResourcesesModel _resourceses;

  public string ShowCost()
  {
      return _resourceses.GetType().ToString();
  }
  public EBuildingType BuildingType => _buildingType;
}