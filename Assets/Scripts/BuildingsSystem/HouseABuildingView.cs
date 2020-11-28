using UnityEngine;

public class HouseABuildingView : ABuildingView, IBuilding
{

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
        if (IsBuy)
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
        throw new System.NotImplementedException();
    }

    // public void SetData()
    // {
    //     _goldIncome = _buildingDatabase.GoldIncome;
    //     _goldCost = _buildingDatabase.GoldCost;
    //     _woodCost = _buildingDatabase.WoodCost;
    //     _name = _buildingDatabase.Name;
    // }

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

    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;

    public void SetTransparent(bool available)
    {
        if (available)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }

    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}