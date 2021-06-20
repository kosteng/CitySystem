using System.Collections.Generic;
using System.Linq;
using Engine.Mediators;
using Items.InteractItems;
using Items.InteractItems.Interfaces;
using static UnityEngine.Object;

namespace Items
{
    public class InteractableItemController : IUpdatable
    {
        private readonly IInteractItemFactory _itemFactory;
        private readonly InteractableItemView _itemView;
        private List<IInteractableItem> _items;

        public InteractableItemController(IInteractItemFactory itemFactory)
        {
            _itemFactory = itemFactory;

            var interactObjects = FindObjectsOfType<InteractableItemView>() as IInteractableItem[];
            _items = interactObjects.ToList();
            for (int i = 0; i < 10; i++)
            {
                _items.Add(_itemFactory.Create(EInteractItemType.TreeFir));
                _items.Add(_itemFactory.Create(EInteractItemType.TreeOak));
                _items.Add(_itemFactory.Create(EInteractItemType.TreeFir));
                _items.Add(_itemFactory.Create(EInteractItemType.TreeFir));
                _items.Add(_itemFactory.Create(EInteractItemType.TreeOak));
                _items.Add(_itemFactory.Create(EInteractItemType.TreePoplar));
                _items.Add(_itemFactory.Create(EInteractItemType.TreePoplar));
                _items.Add(_itemFactory.Create(EInteractItemType.TreePalm));
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var item in _items)
            {
                item.CheckRespawnStatus();
            }
        }
    }
}