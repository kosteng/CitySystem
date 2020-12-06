//TODO требуется написать универсальный механизм сравнения и обработки двух моделей не зависимый от конкретных ресурсов

public class PurchaseBuildingsHandler
{
    public bool TryPurchaseBuilding(ResourcesesModel purchaser, ResourcesesModel cost)
    {
        return purchaser.Gold >= cost.Gold
               && purchaser.Wood >= cost.Wood
               && purchaser.Stone >= cost.Stone;
    }

    public void PurchaseBuilding(ResourcesesModel purchaser, ResourcesesModel cost)
    {
        purchaser.Gold -= cost.Gold;
        purchaser.Wood -= cost.Wood;
        purchaser.Stone -= cost.Stone;
    }
}