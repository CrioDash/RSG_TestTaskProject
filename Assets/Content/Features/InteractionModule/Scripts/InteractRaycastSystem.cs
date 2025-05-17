using System;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.BuyItemModule.Scripts;
using Content.Features.CameraModule;
using Content.Features.PlayerData.Scripts;
using Core.InputModule;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Content.Features.InteractionModule {
    internal class InteractRaycastSystem : IInitializable, IDisposable {
        private const float MAX_DISTANCE = 1000;
        private readonly IInputListener _inputListener;
        private readonly PlayerCameraModel _playerCameraModel;
        private readonly InteractConfiguration _interactConfiguration;
        private readonly DiContainer _container;
        private readonly PlayerEntityModel _playerEntityModel;
        private readonly IEntityBehaviourFactory _entityBehaviourFactory;
        private readonly TradeTableModel _tradeTableModel;

        public InteractRaycastSystem(DiContainer container, 
            IInputListener inputListener, 
            PlayerCameraModel playerCameraModel, 
            InteractConfiguration interactConfiguration, 
            PlayerEntityModel playerEntityModel, 
            IEntityBehaviourFactory entityBehaviourFactory,
            TradeTableModel tradeTableModel) {
            _container = container;
            _playerEntityModel = playerEntityModel;
            _playerCameraModel = playerCameraModel;
            _inputListener = inputListener;
            _interactConfiguration = interactConfiguration;
            _entityBehaviourFactory = entityBehaviourFactory;
            _tradeTableModel = tradeTableModel;
        }

        public void Initialize() => 
            _inputListener.OnInteractionPerformed += HandleRaycast;

        public void Dispose() =>
            _inputListener.OnInteractionPerformed -= HandleRaycast;

        private void HandleRaycast(Vector2 mousePosition) {
            if (_playerCameraModel.CurrentCamera is null || EventSystem.current.IsPointerOverGameObject(Mouse.current.deviceId))
                return;
            
            Ray ray = _playerCameraModel.CurrentCamera.ScreenPointToRay(mousePosition);

            var hits = Physics.RaycastAll(ray, MAX_DISTANCE, _interactConfiguration.PlayerInteractLayers);

            if (hits.Length <= 0)
                return;
            
            _tradeTableModel.Hide();
            
            foreach (RaycastHit hit in hits) {
                if (hit.collider != null && hit.collider.TryGetComponent(out IInteractable interactable)) {
                    {
                        if(hit.collider.GetComponent<PlayerRegister>() != null)
                            continue;
                        
                        interactable.Interact(_playerEntityModel.PlayerEntity);
                        return;
                    }
                }
            }

            SetPlayerEntityPositionToMove(hits[0].point);
        }

        private void SetPlayerEntityPositionToMove(Vector3 position) {
            MoveToPointEntityBehaviour moveToPointEntityBehaviour = _entityBehaviourFactory.GetEntityBehaviour<MoveToPointEntityBehaviour>();
            moveToPointEntityBehaviour.SetMoveToPosition(position);
            _playerEntityModel.PlayerEntity.SetBehaviour(moveToPointEntityBehaviour);
        }
    }
}