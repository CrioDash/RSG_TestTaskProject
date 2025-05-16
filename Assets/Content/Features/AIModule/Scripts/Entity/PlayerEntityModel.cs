using System;

namespace Content.Features.AIModule.Scripts.Entity {
    public class PlayerEntityModel {
        private IEntity _playerEntity;

        public IEntity PlayerEntity {
            get =>
                _playerEntity;
            set {
                if(_playerEntity == value)
                    return;
                
                _playerEntity = value;
                OnPlayerEntityChanged?.Invoke();
            }
        }

        public event Action OnPlayerEntityChanged;
    }
}