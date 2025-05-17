using System;
using Content.Features.AIModule.Scripts;
using Content.Features.HealthModule.Scripts;
using Content.Features.InteractionModule;
using UnityEngine;
using Zenject;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoBehaviour, IDamageable {
        [SerializeField] private int _health;
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

        public void Damage(int damage) {
            _health -= damage;
            OnDamaged?.Invoke();

            if(_damageableType == DamageableType.Player) 
                _playerHealthModel.TakeDamage(damage);
            
            if (_health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        public void SetHealth(int health)
        {
            _health = health;
            Debug.Log($"Current Health: {_health}");
        }
    }
}