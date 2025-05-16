using System;
using Content.Features.AIModule.Scripts;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoBehaviour, IDamageable {
        [SerializeField] private float _health;
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;
    
        public Vector3 Position =>
            transform.position;
        public DamageableType DamageableType =>
            _damageableType;
        public bool IsActive =>
            _health > 0;
        public AttackInteractable Interactable =>
            _attackInteractable;

        public event Action OnDamaged;
        public event Action OnKilled;

        public void Damage(float damage) {
            _health -= damage;
            OnDamaged?.Invoke();

            if (_health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        public void SetHealth(float health) =>
            _health = health;
    }
}