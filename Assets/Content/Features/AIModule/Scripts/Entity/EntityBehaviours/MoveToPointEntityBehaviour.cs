using System;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class MoveToPointEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private Vector3 _moveToPosition;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void SetMoveToPosition(Vector3 teleportPosition) =>
            _moveToPosition = teleportPosition;

        public void Start() =>
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;

        public void Process() {
            if (IsNearTheTarget())
                StopMoving();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_moveToPosition);

        private void StopMoving() {
            _entityContext.NavMeshAgent.ResetPath();
            OnBehaviorEnd?.Invoke();
        }

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityContext.EntityDamageable.Position, _moveToPosition) <= _entityContext.EntityData.InteractDistance;
    }
}