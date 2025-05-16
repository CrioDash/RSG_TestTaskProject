using System;
using UnityEngine;

namespace Core.InputModule {
    public interface IInputListener : DefaultInputActions.IPlayerActions, DefaultInputActions.IUIActions {
        public event Action<Vector2> OnInteractionPerformed;
        public event Action<Vector2> OnInteractionStarted;
        public event Action<Vector2> OnInteractionCanceled;
    }
}