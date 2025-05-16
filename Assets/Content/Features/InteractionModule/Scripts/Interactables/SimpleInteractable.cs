using Content.Features.AIModule.Scripts;
using Content.Features.AIModule.Scripts.Entity;
using UnityEngine;
using UnityEngine.Events;

namespace Content.Features.InteractionModule.Interactables {
    public class SimpleInteractable : MonoBehaviour, IInteractable {
        [SerializeField] private UnityEvent _onInteract;

        public void Interact(IEntity entity) =>
            _onInteract?.Invoke();
    }
}
