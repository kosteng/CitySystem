using System.Collections.Generic;
using System.Linq;
using Engine.Mediators;
using UnityEngine;
using static UnityEngine.Object;


public class InteractableItemController : IUpdatable
{
    private readonly InteractableItemView _itemView;
    private List<IInteractableItem> _items = new List<IInteractableItem>();
    public InteractableItemController(InteractableItemView itemView)
    {
        _itemView = Instantiate(itemView, new Vector3(3, 0, 5), Quaternion.identity);
        var objects = FindObjectsOfType<InteractableItemView>() as IInteractableItem[];
        _items = objects.ToList();
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _items)
        {
            item.CheckRespawnStatus();
        }
    }
}
