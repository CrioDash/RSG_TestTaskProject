using System;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class IdleEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void Start() {
            _entityContext.EntityAnimator.SetIsAttacking(false);
            _entityContext.NavMeshAgent.ResetPath();
        }

        public void Process() { }

        public void Stop() { }
    }
}