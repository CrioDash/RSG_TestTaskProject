using Content.Features.EntityAnimatorModule.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace Content.Features.AIModule.Scripts.Entity {
    public class EntityAnimatorSpeedSetter : MonoBehaviour {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EntityAnimator _entityAnimator;

        private void Update() =>
            _entityAnimator.SetSpeed(_navMeshAgent.velocity.magnitude);
    }
}