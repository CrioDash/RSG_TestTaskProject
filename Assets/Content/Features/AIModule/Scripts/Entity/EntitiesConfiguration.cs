using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity {
    [CreateAssetMenu(menuName = "Configurations/Entity/" + nameof(EntitiesConfiguration), 
        fileName = nameof(EntitiesConfiguration) + "_Default", order = 0)]
    public class EntitiesConfiguration : ScriptableObject {
        [SerializeField] private List<EntityData> _entityDatas;
        [SerializeField] private EntityData _defaultEntityData;

        public EntityData GetDataForEntity(EntityType entityType) =>
            _entityDatas.FirstOrDefault(data => data.EntityType == entityType) ?? _defaultEntityData;
    }
}