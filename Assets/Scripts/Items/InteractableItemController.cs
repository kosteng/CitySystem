using System.Collections.Generic;
using System.Linq;
using Engine.Mediators;
using Extensions.Pool;
using static UnityEngine.Object;

namespace Items
{
    public class InteractableItemController : IUpdatable
    {
        private readonly Items.IInteractItemFactory _itemFactory;
        private readonly InteractableItemView _itemView;
        private List<IInteractableItem> _items;

        public InteractableItemController(Items.IInteractItemFactory itemFactory)
        {
            _itemFactory = itemFactory;

            var interactObjects = FindObjectsOfType<InteractableItemView>() as IInteractableItem[];
            _items = interactObjects.ToList();
            for (int i = 0; i < 10; i++)
            {
                _items.Add(_itemFactory.Create(EInteractItemType.Tree));
                _items.Add(_itemFactory.Create(EInteractItemType.Tree));
                _items.Add(_itemFactory.Create(EInteractItemType.Tree));
                _items.Add(_itemFactory.Create(EInteractItemType.Tree));
                _items.Add(_itemFactory.Create(EInteractItemType.Cube));
                _items.Add(_itemFactory.Create(EInteractItemType.Cube));
                _items.Add(_itemFactory.Create(EInteractItemType.Cube));
                _items.Add(_itemFactory.Create(EInteractItemType.Cube));
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