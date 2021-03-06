﻿using System;
using Engine.Mediators;
using UnityEngine;

public class BuildingsStacker : IUpdatable
{
    private ABuildingView _flyingBuilding;
    public Action IsBuildingMontage;
    public void StartPlacingBuilding(ABuildingView buildingPrefab)
    {

        if (_flyingBuilding != null)
        {
            //TODO возвращать в пул
            MonoBehaviour.Destroy(_flyingBuilding.gameObject);
        }

        _flyingBuilding = buildingPrefab;
    }

    public void Update(float deltaTime)
    {
        if (_flyingBuilding == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _flyingBuilding.SetTransparent(_flyingBuilding.IsPlaceFree);

        if (!Physics.Raycast(ray, out var hit)) return;
        _flyingBuilding.transform.position = new Vector3(hit.point.x, 0f, hit.point.z);

        if (Input.GetMouseButtonDown(0))
            PlaceFlyingBuilding(_flyingBuilding.IsPlaceFree);
    }


    private void PlaceFlyingBuilding(bool isPlaceFree)
    {
        if (!isPlaceFree)
            return;
        
        IsBuildingMontage?.Invoke();
        _flyingBuilding.SetNormal();
        _flyingBuilding = null;
    }
}