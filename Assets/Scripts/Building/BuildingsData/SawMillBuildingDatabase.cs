using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/SawMillBuilding")]
public class SawMillBuildingDatabase : ABuildingDatabase, IBuildingIncome
{
    [SerializeField] private float _woodIncome;
    [SerializeField] private float _goldCost;
    [SerializeField] private float _woodCost;

    public void Income()
    {
        if(IsBuy)
            CityDatabase.Wood += _woodIncome;
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
        IsBuy = true;
    }

    public override string ShowCost()
    {
        return "Gold: " + _goldCost + " Wood: " + _woodCost;
    }

    protected override bool TryBuyBuilding()
    {
        if (CityDatabase.Gold > _goldCost && CityDatabase.Wood > _woodCost)
            return true;
        else return false;
    }
}
