namespace Building
{
    public interface IBuilding
    {
        string Name { get; }
        bool IsBuy { get; }
        void SetActive(bool value);
        void Income();
        void PayBuilding();
        void SetData();
        bool TryBuyBuilding();
        string ShowCost();
    }
}