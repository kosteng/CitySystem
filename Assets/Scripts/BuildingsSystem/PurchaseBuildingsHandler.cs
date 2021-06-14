//TODO требуется написать универсальный механизм сравнения и обработки двух моделей не зависимый от конкретных ресурсов

using City;

namespace BuildingsSystem
{
    public class PurchaseBuildingsHandler
    {
        public bool TryPurchaseBuilding(ResourcesModel purchaser, ResourcesModel cost)
        {
            return purchaser.Gold.Amount >= cost.Gold.Amount
                   && purchaser.Wood.Amount >= cost.Wood.Amount
                   && purchaser.Stone.Amount >= cost.Stone.Amount;
        }

        public void PurchaseBuilding(ResourcesModel purchaser, ResourcesModel cost)
        {
            purchaser.Gold.Amount -= cost.Gold.Amount;
            purchaser.Wood.Amount -= cost.Wood.Amount;
            purchaser.Stone.Amount -= cost.Stone.Amount;
        }
    }
}