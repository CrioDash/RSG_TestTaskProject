using Content.Features.PlayerData.Scripts;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Content.Features.CameraModule {
    public class CinemachineCameraSetup : MonoBehaviour {
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        private PlayerTransformModel _playerTransformModel;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel) =>
            _playerTransformModel = playerTransformModel;

        private void Start() {
            if (_playerTransformModel.PlayerTransform != null)
                SwitchTarget(_playerTransformModel.PlayerTransform);
        }

        private void OnEnable() =>
            _playerTransformModel.OnPlayerTransformChanged += SwitchTarget;

        private void OnDisable() =>
            _playerTransformModel.OnPlayerTransformChanged -= SwitchTarget;

        private void SwitchTarget(Transform target) =>
            _cinemachineCamera.Target.TrackingTarget = target;
    }
}