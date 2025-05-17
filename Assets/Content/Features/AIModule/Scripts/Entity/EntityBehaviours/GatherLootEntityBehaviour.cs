using System;
using Content.Features.InventoryModule.Scripts;
using Content.Features.LootModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class GatherLootEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private Loot _loot;
        private ILootService _lootService;
        private readonly PlayerInventoryModel _playerInventoryModel;

        public event Action OnBehaviorEnd;

        public GatherLootEntityBehaviour(ILootService lootService,
            PlayerInventoryModel playerInventoryModel)
        {
            _lootService = lootService;
            _playerInventoryModel = playerInventoryModel;
        }

        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void SetLoot(Loot loot) =>
            _loot = loot;

        public void Start() {
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;
        }

        public void Process() {
            if(IsNearTheTarget() && !_playerInventoryModel.IsInventoryFull())
                CollectLoot();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_loot.transform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityContext.EntityDamageable.Position, _loot.transform.position) <= _entityContext.EntityData.InteractDistance;
        

        private void CollectLoot() {
            _lootService.CollectLoot(_loot, _entityContext.Storage);
            
            _loot.DestroyLoot();
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }
    }
}