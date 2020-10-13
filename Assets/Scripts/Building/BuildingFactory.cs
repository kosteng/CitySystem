using UnityEngine;

namespace Building
{
    // TO DO переписать этого монстра!!! сделать отдельный класс с префабами и координатами построек
    public class BuildingFactory : MonoBehaviour
    {
        [SerializeField] private HouseBuildingView _BuildingPrefabs;
        [SerializeField] private Transform _positionBuildingСoordinates;
        
        [SerializeField] private Transform _parentGameObject;

        public HouseBuildingView Create()
        {
            var building = Instantiate(_BuildingPrefabs, _positionBuildingСoordinates.position, Quaternion.identity, _parentGameObject);
            building.transform.rotation = _positionBuildingСoordinates.rotation;
            return building;
        }
    }
}
