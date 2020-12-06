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
  [SerializeField] private ResourcesesModel _costResourceses;
  [SerializeField] private ResourcesesModel _incomeResourceses;

  public ResourcesesModel CostResourceses => _costResourceses;

  public ResourcesesModel IncomeResourceses => _incomeResourceses;

  //TODO выводить только не нулевые ресурсы
  public string ShowCost()
  {
      return $"Cost: Gold: {_costResourceses.Gold} Wood: {_costResourceses.Wood} Stone: {_costResourceses.Stone}";
  }
  public EBuildingType BuildingType => _buildingType;

  public ABuildingView View => _view;
}