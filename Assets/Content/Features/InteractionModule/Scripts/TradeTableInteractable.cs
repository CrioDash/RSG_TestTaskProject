using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.BuyItemModule.Scripts;
using Content.Features.ShopModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule.Scripts
{
    public class TradeTableInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject tradeTable;
        private IEntityBehaviourFactory _entityBehaviourFactory;
        private TradeTableModel _tradeTableModel;
            
        [Inject]
        public void InjectDependencies(IEntityBehaviourFactory entityBehaviourFactory,
            TradeTableModel tradeTableModel)
        {
            _entityBehaviourFactory = entityBehaviourFactory;
            _tradeTableModel = tradeTableModel;
        }

        public void Interact(IEntity entity) {
            TradeTableEntityBehaviour tradeTableEntityBehaviour = _entityBehaviourFactory.GetEntityBehaviour<TradeTableEntityBehaviour>();
            tradeTableEntityBehaviour.SetTable(tradeTable, _tradeTableModel);
            entity.SetBehaviour(tradeTableEntityBehaviour);
        }
    }
}