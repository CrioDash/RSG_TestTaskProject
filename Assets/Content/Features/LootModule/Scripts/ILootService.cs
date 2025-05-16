using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public interface ILootService {
        void CollectLoot(Loot loot, IStorage storage);
    }
}