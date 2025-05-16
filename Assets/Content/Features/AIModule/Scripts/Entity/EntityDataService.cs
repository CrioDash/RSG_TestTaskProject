namespace Content.Features.AIModule.Scripts.Entity {
    public class EntityDataService : IEntityDataService {
        private EntitiesConfiguration _entitiesConfiguration;

        public EntityDataService(EntitiesConfiguration entitiesConfiguration) =>
            _entitiesConfiguration = entitiesConfiguration;

        public EntityData GetEntityData(EntityType entityType) =>
            _entitiesConfiguration.GetDataForEntity(entityType);
    }
}