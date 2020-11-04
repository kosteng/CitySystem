using UnityEngine;

    [CreateAssetMenu(menuName = "DatabasesSO/HouseBuilding")]
    public class HouseBuildingDatabase : ScriptableObject
    {
        public string Name;
        public float GoldIncome;
        public float GoldCost;
        public float WoodCost;
        [SerializeField] private CityDatabase _cityDatabase;
        public string ShowCost()
        {
            return "Gold: " + GoldCost + " Wood: " + WoodCost;
        }
        
        public bool TryBuyBuilding()
        {
            if (_cityDatabase.Gold > GoldCost && _cityDatabase.Wood > WoodCost)
                return true;
            else return false;
        }
    }

