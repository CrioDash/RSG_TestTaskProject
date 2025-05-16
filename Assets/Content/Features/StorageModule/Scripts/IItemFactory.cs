namespace Content.Features.StorageModule.Scripts {
    public interface IItemFactory {
        public Item GetItem(ItemType itemType);
    }
}