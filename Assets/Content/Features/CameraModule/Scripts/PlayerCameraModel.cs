using System;
using UnityEngine;

namespace Content.Features.CameraModule {
    public class PlayerCameraModel {
        private Camera _currentCamera;
        
        public Camera CurrentCamera {
            get =>
                _currentCamera;
            set {
                OnPlayerCameraChanged?.Invoke(value);
                _currentCamera = value;
            }
        }
        public event Action<Camera> OnPlayerCameraChanged;
    }
}