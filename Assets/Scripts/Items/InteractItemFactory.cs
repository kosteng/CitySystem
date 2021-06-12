using System.Linq;
using UnityEngine;

public class InteractItemFactory : IFactory<IInteractableItem>
{
    private readonly InteractItemDatabase _itemDatabase;

    public InteractItemFactory(InteractItemDatabase itemDatabase)
    {
        _itemDatabase = itemDatabase;
    }

    public IInteractableItem Create()
    {
        return null;
    }

    public IInteractableItem Create(EInteractItemType prefab)
    {
        int x = Random.Range(-150, 150);
        int z = Random.Range(-150, 150);

        var gPrefab = _itemDatabase.InteractableItemViews.FirstOrDefault(i => i.ItemType == prefab);
      
        return Object.Instantiate(gPrefab, new Vector3(x, 0, z), Quaternion.identity);
    }
}