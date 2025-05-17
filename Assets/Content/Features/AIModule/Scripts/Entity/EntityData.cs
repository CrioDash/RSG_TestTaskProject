using System;

namespace Content.Features.AIModule.Scripts.Entity {
    [Serializable]
    public class EntityData {
        public EntityType EntityType;
        public int StartHealth;
        public int Damage;
        public float AttackDistance;
        public float InteractDistance;
        public float Speed;
        public int MaxInventoryWeight;
    }
}