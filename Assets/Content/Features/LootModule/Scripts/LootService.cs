using System.Linq;
using Content.Features.InventoryModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public class LootService : ILootService {
        private IItemFactory _itemFactory;
        private readonly PlayerInventoryModel _playerInventoryModel;

        public LootService(IItemFactory itemFactory,
            PlayerInventoryModel playerInventoryModel)
        {
            _itemFactory = itemFactory;
            _playerInventoryModel = playerInventoryModel;
        }

        public void CollectLoot(Loot loot, IStorage storage) {
            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                var item = _itemFactory.GetItem(itemType);
                
                _playerInventoryModel.AddItem(itemType, item);
            }
        }

        public int GetLootWeight(Loot loot)
        {
            return loot.GetItemsInLoot().Sum(item => _itemFactory.GetItem(item).Weight);
        }
    }
}