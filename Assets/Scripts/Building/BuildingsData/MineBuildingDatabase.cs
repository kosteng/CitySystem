using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/MineBuilding")]
public class MineBuildingDatabase : ABuildingDatabase, IBuildingIncome
{
    [SerializeField] private float _ironIncome;
    [SerializeField] private float _stoneIncome;
    [SerializeField] private float _goldCost;
   [SerializeField] private float _woodCost;
  //  [SerializeField] private float _stoneCost;

    public void Income()
    {
        if (IsBuy)
        {
            CityDatabase.Stone += _stoneIncome;
            CityDatabase.Iron += _ironIncome;
        }
    }

    public override void PayBuilding()
    {
        if (!TryBuyBuilding())
        {
            Debug.Log("Не хватает ресурсов");
            return;
        }

        CityDatabase.Gold -= _goldCost;
        CityDatabase.Wood -= _woodCost;
       // CityDatabase.Stone -= _stoneCost;
        IsBuy = true;
    }

    public override string ShowCost()
    {
        return "Gold: " + _goldCost + " Wood: " + _woodCost;
    }

    protected override bool TryBuyBuilding()
    {
        if (CityDatabase.Gold > _goldCost && CityDatabase.Wood > _woodCost /*&& CityDatabase.Stone > _stoneCost*/)
            return true;
        else return false;
    }
}


