using System;
using Content.Features.DamageablesModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class AttackEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private IDamageable _targetDamageable;

        public event Action OnBehaviorEnd;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void SetTarget(IDamageable damageable) =>
            _targetDamageable = damageable;
        
        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
            _entityContext.EntityAnimator.OnAttackTriggered += OnAttackTriggered;
        }

        public void Process() {
            if(_targetDamageable.IsActive is false) {
                OnBehaviorEnd?.Invoke();
                return;
            }

            if(IsNearTheTarget())
                StartAttacking();
            else
                MoveToTarget();
        }

        public void Stop() =>
            _entityContext.EntityAnimator.OnAttackTriggered -= OnAttackTriggered;

        private void MoveToTarget() {
            if(_targetDamageable.IsActive is false)
                return;
            
            _entityContext.EntityAnimator.SetIsAttacking(false);
            _entityContext.NavMeshAgent.SetDestination(_targetDamageable.Position);
        }

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() {
            if (_targetDamageable.IsActive is false)
                return false;
            
            return Vector3.Distance(_entityContext.EntityDamageable.Position, _targetDamageable.Position) <= _entityContext.EntityData.AttackDistance;
        }

        private void StartAttacking() {
            _entityContext.EntityAnimator.SetIsAttacking(true);
            StopMoving();
        }

        private void OnAttackTriggered() =>
            _targetDamageable.Damage(_entityContext.EntityData.Damage);
    }
}