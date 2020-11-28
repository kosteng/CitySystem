using UnityEngine;


// TO DO переписать этого монстра!!! сделать отдельный класс с префабами и координатами построек
public class BuildingFactory : MonoBehaviour
{
    [SerializeField] private HouseABuildingView aBuildingPrefabs;
    [SerializeField] private Transform _positionBuildingСoordinates;

    [SerializeField] private Transform _parentGameObject;

    public HouseABuildingView Create()
    {
        var building = Instantiate(aBuildingPrefabs, _positionBuildingСoordinates.position, Quaternion.identity,
            _parentGameObject);
        building.transform.rotation = _positionBuildingСoordinates.rotation;
        return building;
    }
}