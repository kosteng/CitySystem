using Items.ResourceItems;

namespace Inventory
{
    public interface IInventoryCellBuilder
    {
        InventoryCellView Build(EResourceItemType type);
    }
}