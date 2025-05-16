using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public class LootService : ILootService {
        private IItemFactory _itemFactory;

        public LootService(IItemFactory itemFactory) =>
            _itemFactory = itemFactory;

        public void CollectLoot(Loot loot, IStorage storage) {
            foreach (ItemType itemType in loot.GetItemsInLoot())
                storage.AddItem(_itemFactory.GetItem(itemType));
        }
    }
}