using System;
using Content.Features.EntityAnimatorModule.Scripts;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class IdleEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void Start() {
            if( _entityContext.EntityAnimator == null || _entityContext.NavMeshAgent == null)
                return;
            _entityContext.EntityAnimator.SetIsAttacking(false);
            _entityContext.NavMeshAgent.ResetPath();
        }

        public void Process() { }

        public void Stop() { }
    }
}