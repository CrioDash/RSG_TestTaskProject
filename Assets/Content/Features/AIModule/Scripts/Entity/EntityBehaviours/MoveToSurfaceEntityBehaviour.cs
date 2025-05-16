using System;
using Content.Features.GameFlowStateMachineModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class MoveToSurfaceEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private Vector3 _teleportPosition;
        private GameFlowStateMachine _gameFlowStateMachine;

        public event Action OnBehaviorEnd;

        public MoveToSurfaceEntityBehaviour(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void SetTelepotPosition(Vector3 teleportPosition) =>
            _teleportPosition = teleportPosition;

        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
        }

        public void Process() {
            if (IsNearTheTarget())
                TeleportToSurface();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_teleportPosition);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityContext.EntityDamageable.Position, _teleportPosition) <= _entityContext.EntityData.InteractDistance;

        private void TeleportToSurface() {
            _gameFlowStateMachine.Enter<EnterSurfaceFlowState>();
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }
    }
}