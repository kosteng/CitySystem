using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using Items;
using Items.InteractItems;
using Units.Controllers;
using Units.Views;
using UnityEngine;

public class InteractableItemModel
{
    private readonly InteractableItemView _itemView;

    private float _respawnTime;
    private float _life;
    private float _canDistance;
    public InteractableItemModel(InteractableItemView itemView)
    {
        _itemView = itemView;
    }

}
