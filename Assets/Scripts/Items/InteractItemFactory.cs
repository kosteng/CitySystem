using System.Linq;
using UnityEngine;

namespace Items
{
    public class InteractItemFactory : IInteractItemFactory
    {
        private readonly InteractItemDatabase _itemDatabase;

        public InteractItemFactory(InteractItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        public IInteractableItem Create(EInteractItemType type)
        {
            int x = Random.Range(-50, 50);
            var rotation = Random.rotation.y;
            int z = Random.Range(-50, 50);

            var prefab = _itemDatabase.InteractableItemViews.FirstOrDefault(i => i.ItemType == type);
      
            return Object.Instantiate(prefab, new Vector3(x, 0, z), Quaternion.Euler(0,rotation,0));
        }
    }
}