using System;
using Content.Features.AIModule.Scripts.Entity;
using Core.UiModule.Scripts;
using UnityEngine;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthModel : IUiModel
    {
        public float CurrentHealth { get; set; } = 0;
        public float MaxHealth { get; set; } = 0;

        public EntityContext PlayerEntity;
        
        public event Action OnChangeHealth;

        public void SetCurrentHealth(float amount)
        {
            CurrentHealth = amount;

            OnChangeHealth?.Invoke();
        }

        public void SetMaxHealth(float amount, EntityContext entity)
        {
            PlayerEntity = entity;
            if(MaxHealth != 0)
                return;
            MaxHealth = CurrentHealth = amount;
            OnChangeHealth?.Invoke();
        }

}
}