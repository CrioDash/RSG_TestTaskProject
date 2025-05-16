using System;

namespace Content.Features.AIModule.Scripts.Entity {
    [Serializable]
    public class EntityData {
        public EntityType EntityType;
        public float StartHealth;
        public float Damage;
        public float AttackDistance;
        public float InteractDistance;
        public float Speed;
    }
}