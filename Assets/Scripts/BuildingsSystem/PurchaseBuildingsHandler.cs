//TODO требуется написать универсальный механизм сравнения и обработки двух моделей не зависимый от конкретных ресурсов

using City;

namespace BuildingsSystem
{
    public class PurchaseBuildingsHandler
    {
        public bool TryPurchaseBuilding(ResourcesModel purchaser, ResourcesModel cost)
        {
            return purchaser.Gold >= cost.Gold
                   && purchaser.Wood >= cost.Wood
                   && purchaser.Stone >= cost.Stone;
        }

        public void PurchaseBuilding(ResourcesModel purchaser, ResourcesModel cost)
        {
            purchaser.Gold -= cost.Gold;
            purchaser.Wood -= cost.Wood;
            purchaser.Stone -= cost.Stone;
        }
    }
}