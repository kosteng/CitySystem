using UnityEngine;

public abstract class ABuildingDatabase : ScriptableObject, IBuildingIncome
{
    [SerializeField] protected CityDatabase CityDatabase;

    public string Name;
    public bool IsBuy = false;
    protected abstract bool TryBuyBuilding();
    public abstract void PayBuilding();
    public abstract string ShowCost();
    public void Income()
    {
    }

    public void Clear()
    {
        IsBuy = false;
    }
}
