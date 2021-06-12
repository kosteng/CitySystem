using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DatabasesSO/InteractItemDatabase")]
public class InteractItemDatabase : ScriptableObject
{
    [SerializeField] private InteractableItemView[] _itemViews;
    public InteractableItemView[] InteractableItemViews => _itemViews;
}
