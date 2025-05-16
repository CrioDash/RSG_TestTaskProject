using System;
using Content.Features.DamageablesModule.Scripts;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class IdleSearchForTargetsEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void Start() {
            _entityContext.EntityAnimator.SetIsAttacking(false);
            _entityContext.NavMeshAgent.ResetPath();
        }

        public void Process() {
            if (!_entityContext.TargetsFinder.TryFindDamageable(out IDamageable damageable))
                return;

            damageable.Interactable.Interact(_entityContext.Entity);
            OnBehaviorEnd?.Invoke();
        }

        public void Stop() { }
    }
}