using System;
using Content.Features.DamageablesModule.Scripts;
using Content.Features.EntityAnimatorModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine.AI;

namespace Content.Features.AIModule.Scripts.Entity {
    [Serializable]
    public class EntityContext {
        public EntityAnimator EntityAnimator;
        public NavMeshAgent NavMeshAgent;
        public TargetsFinder TargetsFinder;
        public EntityData EntityData;
        
        public IDamageable EntityDamageable;
        public IEntity Entity;
        public IStorage Storage;
    }
}