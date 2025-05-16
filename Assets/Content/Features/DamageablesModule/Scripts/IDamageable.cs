using System;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts {
    public interface IDamageable {
        public Vector3 Position { get; }
        public DamageableType DamageableType { get; }
        public bool IsActive { get; }
        public AttackInteractable Interactable { get; } 

        public event Action OnDamaged;
        public event Action OnKilled;
        public void Damage(float damage);
        public void SetHealth(float health);
    }
}