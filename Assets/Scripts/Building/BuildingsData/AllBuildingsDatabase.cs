using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="DatabasesSO/AllBuildingsDatabase")]
public class AllBuildingsDatabase : ScriptableObject
{
    [SerializeField] private List<ABuildingDatabase> _buildingsDatabase;
    public Dictionary<EBuildingType, ABuildingDatabase> Buildings = new Dictionary<EBuildingType, ABuildingDatabase>();

    public void Init()
    {       
        Buildings.Add(EBuildingType.House, _buildingsDatabase[0]);
        Buildings.Add(EBuildingType.SawMill, _buildingsDatabase[1]);
        Buildings.Add(EBuildingType.Mine, _buildingsDatabase[2]);
        Debug.Log(Buildings.Count);
    }
}
