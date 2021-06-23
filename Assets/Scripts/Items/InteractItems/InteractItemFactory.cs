using Items.InteractItems;
using Items.InteractItems.Interfaces;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class InteractItemFactory : IInteractItemFactory
    {
        private readonly InteractItemsDatabase _itemsDatabase;
        private GameObject _parent;

        public InteractItemFactory(InteractItemsDatabase itemsDatabase)
        {
            _itemsDatabase = itemsDatabase;
            _parent = new GameObject("InteractItems");
        }

        public IInteractableItem Create(EInteractItemType type)
        {
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);
            var rotation = Random.rotation.y;

            var prefab = _itemsDatabase.InteractItemsData.FirstOrDefault(i => i.Type == type);
            var item = Object.Instantiate(prefab.ItemView, new Vector3(x, 0, z), Quaternion.Euler(0, rotation, 0));
            item.transform.SetParent(_parent.transform);
            
            return item;
        }
    }
}