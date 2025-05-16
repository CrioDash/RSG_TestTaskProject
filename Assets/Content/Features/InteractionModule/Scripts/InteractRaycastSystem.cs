using System;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.CameraModule;
using Core.InputModule;
using UnityEngine;
using Zenject;

namespace Content.Features.InteractionModule {
    internal class InteractRaycastSystem : IInitializable, IDisposable {
        private const float MAX_DISTANCE = 1000;
        private readonly IInputListener _inputListener;
        private readonly PlayerCameraModel _playerCameraModel;
        private readonly InteractConfiguration _interactConfiguration;
        private readonly PlayerEntityModel _playerEntityModel;
        private readonly IEntityBehaviourFactory _entityBehaviourFactory;

        public InteractRaycastSystem(IInputListener inputListener,
                                     PlayerCameraModel playerCameraModel,
                                     InteractConfiguration interactConfiguration, 
                                     PlayerEntityModel playerEntityModel, 
                                     IEntityBehaviourFactory entityBehaviourFactory) {
            _playerEntityModel = playerEntityModel;
            _playerCameraModel = playerCameraModel;
            _inputListener = inputListener;
            _interactConfiguration = interactConfiguration;
            _entityBehaviourFactory = entityBehaviourFactory;
        }

        public void Initialize() => 
            _inputListener.OnInteractionPerformed += HandleRaycast;

        public void Dispose() =>
            _inputListener.OnInteractionPerformed -= HandleRaycast;

        private void HandleRaycast(Vector2 mousePosition) {
            if (_playerCameraModel.CurrentCamera is null)
                return;
            
            Ray ray = _playerCameraModel.CurrentCamera.ScreenPointToRay(mousePosition);
            RaycastHit[] hits = new RaycastHit[_interactConfiguration.MaxHits];

            if (Physics.RaycastNonAlloc(ray, hits, MAX_DISTANCE, _interactConfiguration.PlayerInteractLayers) <= 0)
                return;

            foreach (RaycastHit hit in hits) {
                if (hit.collider != null && hit.collider.TryGetComponent(out IInteractable interactable)) {
                    interactable.Interact(_playerEntityModel.PlayerEntity);
                    return;
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