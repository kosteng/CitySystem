using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using Units.Controllers;
using Units.Views;
using UnityEngine;

public class InteractableItemModel
{
    private readonly InteractableItemView _itemView;
    private readonly CharacterMovementController _characterMovementController;

    private float _respawnTime;
    private float _life;
    private float _canDistance;
    public InteractableItemModel(InteractableItemView itemView, CharacterMovementController characterMovementController)
    {
        _itemView = itemView;
        _characterMovementController = characterMovementController;

    }

    public void Update(float deltaTime)
    {
        _canDistance = Vector3.Distance(_characterMovementController.UnitViewTransform.position,
            _itemView.gameObject.transform.position);
        
        // if (_canDistance < 4f)
        //     _playerMovementController.StopUnit();
    }
}
