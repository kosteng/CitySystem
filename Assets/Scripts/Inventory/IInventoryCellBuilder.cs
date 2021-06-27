using Items.ResourceItems;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public interface IInventoryCellBuilder
    {
        InventoryCellView Build(EResourceItemType type, Transform contentParent, ToggleGroup toggleGroup);
    }
}