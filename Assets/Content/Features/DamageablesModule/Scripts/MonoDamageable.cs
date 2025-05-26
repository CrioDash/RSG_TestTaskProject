using System;
using Content.Features.AIModule.Scripts;
using Content.Features.HealthModule.Scripts;
using Content.Features.InteractionModule;
using UnityEngine;
using Zenject;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoBehaviour, IDamageable {
        [SerializeField] private float _health;
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;

        [Inject] private PlayerHealthModel _playerHealthModel;
        
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

            if (_damageableType == DamageableType.Player)
                _playerHealthModel.SetCurrentHealth(_health);
            
            if (_health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        public void Heal(float heal)
        {
            _health += heal;

            Mathf.Clamp(_health, 0, _playerHealthModel.MaxHealth);

            _playerHealthModel.SetCurrentHealth(_health);
        }

        public void SetHealth(float health)
        {
            _health = health;

            if (_damageableType == DamageableType.Player)
                _playerHealthModel.SetCurrentHealth(health);
        }
    }
}