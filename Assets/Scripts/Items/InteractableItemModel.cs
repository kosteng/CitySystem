using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using Units.Controllers;
using Units.Views;
using UnityEngine;

public class InteractableItemModel
{
    private readonly InteractableItemView _view;
    private readonly CharacterMovementController _characterMovementController;

    private float _respawnTime;
    private float _life;
    private float _canDistance;
    public InteractableItemModel(InteractableItemView view, CharacterMovementController characterMovementController)
    {
        _view = view;
        _characterMovementController = characterMovementController;

    }

    public void Update(float deltaTime)
    {
        _canDistance = Vector3.Distance(_characterMovementController.UnitViewTransform.position,
            _view.gameObject.transform.position);
        
        // if (_canDistance < 4f)
        //     _playerMovementController.StopUnit();
    }
}
