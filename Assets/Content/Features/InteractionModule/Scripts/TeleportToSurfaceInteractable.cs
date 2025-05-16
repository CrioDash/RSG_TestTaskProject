using Content.Features.AIModule.Scripts;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule {
    public class TeleportToSurfaceInteractable : MonoBehaviour, IInteractable {
        private IEntityBehaviourFactory _entityBehaviourFactory;
        
        [Inject]
        public void InjectDependencies(IEntityBehaviourFactory entityBehaviourFactory) =>
            _entityBehaviourFactory = entityBehaviourFactory;

        public void Interact(IEntity entity) {
            MoveToSurfaceEntityBehaviour moveToSurfaceEntityBehaviour = _entityBehaviourFactory.GetEntityBehaviour<MoveToSurfaceEntityBehaviour>();
            moveToSurfaceEntityBehaviour.SetTelepotPosition(transform.position);
            entity.SetBehaviour(moveToSurfaceEntityBehaviour);
        }
    }
}