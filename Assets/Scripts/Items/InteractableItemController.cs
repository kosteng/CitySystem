using UnityEngine;


public class InteractableItemController
{
    private readonly InteractableItemView _itemView;
    
    public InteractableItemController(InteractableItemView itemView)
    {
        _itemView = Object.Instantiate(itemView, new Vector3(3, 0, 5), Quaternion.identity);
    }

}
