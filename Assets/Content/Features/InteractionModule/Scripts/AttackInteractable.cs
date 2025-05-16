using Content.Features.AIModule.Scripts;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.DamageablesModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule {
    public class AttackInteractable : MonoBehaviour, IInteractable {
        private IEntityBehaviourFactory _entityBehaviourFactory;
        
        [Inject]
        public void InjectDependencies(IEntityBehaviourFactory entityBehaviourFactory) =>
            _entityBehaviourFactory = entityBehaviourFactory;

        public void Interact(IEntity entity) {
            AttackEntityBehaviour attackEntityBehaviour = _entityBehaviourFactory.GetEntityBehaviour<AttackEntityBehaviour>();
            attackEntityBehaviour.SetTarget(GetComponent<IDamageable>());
            entity.SetBehaviour(attackEntityBehaviour);
        }
    }
}