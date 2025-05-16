using UnityEngine;
using Zenject;

namespace Content.Features.PlayerData.Scripts {
    public class PlayerRegister : MonoBehaviour {
        private PlayerTransformModel _playerTransformModel;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel) =>
            _playerTransformModel = playerTransformModel;

        private void Awake() =>
            _playerTransformModel.PlayerTransform = transform;
    }
}
