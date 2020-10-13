using Building.BuildingsData;
using UnityEngine;

namespace Building
{
    public class HouseBuildingView : ABuildingView, IBuilding
    {
        [SerializeField] private HouseBuildingDatabase _buildingDatabase;
        private float _goldIncome;
        private float _goldCost;
        private float _woodCost;
        private bool _isBuy = false;
        private string _name;
        public bool IsBuy => _isBuy;

        public string Name => _name;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Income()
        {
            if(IsBuy)
                CityDatabase.Gold += _goldIncome;
        }

        public void PayBuilding()
        {
            if (!TryBuyBuilding())
            {
                Debug.Log("Не хватает ресурсов");
                return;
            }

            CityDatabase.Gold -= _goldCost;
            CityDatabase.Wood -= _woodCost;
            _isBuy = true;
        }

        public void SetData()
        {
            _goldIncome = _buildingDatabase.GoldIncome;
            _goldCost = _buildingDatabase.GoldCost;
            _woodCost = _buildingDatabase.WoodCost;
            _name = _buildingDatabase.Name;
        }

        public string ShowCost()
        {
            return "Gold: " + _goldCost + " Wood: " + _woodCost;
        }

        public bool TryBuyBuilding()
        {
            if (CityDatabase.Gold > _goldCost && CityDatabase.Wood > _woodCost)
                return true;
            else return false;
        }
    }
}
