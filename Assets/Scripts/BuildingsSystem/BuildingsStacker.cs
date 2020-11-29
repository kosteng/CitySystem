using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using UnityEngine;
using Zenject;

public class BuildingsStacker : IUpdatable, IInitializable
{
    private ABuildingView _flyingBuilding;
    private Camera _mainCamera;
    private bool _isPlaceFree;
    public void StartPlacingBuilding(ABuildingView buildingPrefab)
    {
        if (_flyingBuilding != null)
        {
            MonoBehaviour.Destroy(_flyingBuilding.gameObject);
        }

        _flyingBuilding = buildingPrefab;
    }

    public void Update(float deltaTime)
    {
        if (_flyingBuilding != null)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _flyingBuilding.transform.position = new Vector3(hit.point.x, 0f, hit.point.z);


                if (Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(hit.point.x, hit.point.z, _flyingBuilding.IsPlaceFree);
                }
            }
        }
    }


    private void PlaceFlyingBuilding(float placeX, float placeY, bool isPlaceFree)
    {
        if (!isPlaceFree)
        {
            Debug.Log("Место занято!");
            return;
        }
        _flyingBuilding.SetNormal();
        _flyingBuilding = null;
    }

    public void Initialize()
    {
        _mainCamera = Camera.main;
    }
}