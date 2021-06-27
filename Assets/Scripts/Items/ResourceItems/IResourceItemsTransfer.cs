namespace Items.ResourceItems
{
    public interface IResourceItemsTransfer
    {
        void Transfer(IResourcesStorage exporter, IResourcesStorage importer, EResourceItemType type, float amount);
    }
}