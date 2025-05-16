using UnityEngine;
using Zenject;

namespace Content.Features.CameraModule {
    public class PlayerCameraRegister : MonoBehaviour {
        [SerializeField] private Camera _camera;
        private PlayerCameraModel _playerCameraModel;

        [Inject]
        public void InjectDependencies(PlayerCameraModel playerCameraModel) =>
            _playerCameraModel = playerCameraModel;

        private void Awake() =>
            _playerCameraModel.CurrentCamera = _camera;
    }
}