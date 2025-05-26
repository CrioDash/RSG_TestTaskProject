using System;
using Content.Features.BuyItemModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours
{
    public class TradeTableEntityBehaviour : IEntityBehaviour
    {
        private EntityContext _entityContext;
        private GameObject _table;
        private TradeTableModel _tradeTableModel;
            
        public event Action OnBehaviorEnd;
        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;

        public void Start() =>
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;

        public void SetTable(GameObject table, TradeTableModel tradeTableModel)
        {
            _table = table;
            _tradeTableModel = tradeTableModel;
        }

        public void Process() {
            if(IsNearTheTarget())
                OpenBuyItemWindow();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_table.transform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget()
        {
            return Vector3.Distance(_entityContext.EntityDamageable.Position, _table.transform.position) <=
                _entityContext.EntityData.InteractDistance;
        }

        private void OpenBuyItemWindow() {
            _tradeTableModel.Show();
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }
    }
}