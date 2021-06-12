using System.Collections.Generic;
using System.Linq;
using Engine.Mediators;
using static UnityEngine.Object;


public class InteractableItemController : IUpdatable
{
    private readonly IFactory<IInteractableItem> _itemFactory;
    private readonly InteractableItemView _itemView;
    private List<IInteractableItem> _items;

    public InteractableItemController(IFactory<IInteractableItem> itemFactory)
    {
        _itemFactory = itemFactory;
        
        var interactObjects = FindObjectsOfType<InteractableItemView>() as IInteractableItem[];
        _items = interactObjects.ToList();
        _items.Add(_itemFactory.Create(EInteractItemType.Tree));
        _items.Add(_itemFactory.Create(EInteractItemType.Tree));
        _items.Add(_itemFactory.Create(EInteractItemType.Tree));
        _items.Add(_itemFactory.Create(EInteractItemType.Tree));
        _items.Add(_itemFactory.Create(EInteractItemType.Cube));
        _items.Add(_itemFactory.Create(EInteractItemType.Cube));
        _items.Add(_itemFactory.Create(EInteractItemType.Cube));
        _items.Add(_itemFactory.Create(EInteractItemType.Cube));
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _items)
        {
            item.CheckRespawnStatus();
        }
    }
}