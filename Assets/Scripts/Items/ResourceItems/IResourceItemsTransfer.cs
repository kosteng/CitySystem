namespace Items.ResourceItems
{
    public interface IResourceItemsTransfer
    {
        void Transfer(IResourcesStorage exporter, IResourcesStorage importer, EResourceItemType type, float amount);
        void Transfer(IResourcesStorage exporter, EResourceItemType type, float amount);
    }
}