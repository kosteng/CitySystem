using Items.Interfaces;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class InteractItemFactory : IInteractItemFactory
    {
        private readonly InteractItemDatabase _itemDatabase;
        private GameObject _parent;

        public InteractItemFactory(InteractItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
            _parent = new GameObject("InteractItems");
        }

        public IInteractableItem Create(EInteractItemType type)
        {
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);
            var rotation = Random.rotation.y;

            var prefab = _itemDatabase.InteractableItemViews.FirstOrDefault(i => i.ItemType == type);
            var item = Object.Instantiate(prefab, new Vector3(x, 0, z), Quaternion.Euler(0, rotation, 0));
            item.transform.SetParent(_parent.transform);
            
            return item;
        }
    }
}