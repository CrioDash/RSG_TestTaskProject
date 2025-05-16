using Content.Features.AIModule.Scripts;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.LootModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule {
    public class LootInteractable : MonoBehaviour, IInteractable {
        [SerializeField] private Loot _loot;
        private IEntityBehaviourFactory _entityBehaviourFactory;
        
        [Inject]
        public void InjectDependencies(IEntityBehaviourFactory entityBehaviourFactory) =>
            _entityBehaviourFactory = entityBehaviourFactory;

        public void Interact(IEntity entity) {
            GatherLootEntityBehaviour gatherLootEntityBehaviour = _entityBehaviourFactory.GetEntityBehaviour<GatherLootEntityBehaviour>();
            gatherLootEntityBehaviour.SetLoot(_loot);
            entity.SetBehaviour(gatherLootEntityBehaviour);
        }
    }
}