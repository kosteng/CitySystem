using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using Units.Controllers;
using UnityEngine;
using Zenject;

public class InteractableItemController : IInitializable, IUpdatable
{
    private readonly InteractableItemView _itemView;
    private InteractableItemModel _interactableItemModel;
    
    public InteractableItemController(InteractableItemView itemView, CharacterMovementController characterMovementController)
    {
        _itemView = MonoBehaviour.Instantiate(itemView, new Vector3(3, 0, 5), Quaternion.identity);
        _interactableItemModel = new InteractableItemModel(_itemView, characterMovementController);
    }

    public void Initialize()
    {

    }

    public void Update(float deltaTime)
    {
        _interactableItemModel.Update(deltaTime);
    }
}
