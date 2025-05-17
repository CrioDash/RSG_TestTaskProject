using System;
using Core.UiModule.Scripts;
using UnityEngine;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthModel : IUiModel
    {
        public int CurrentHealth { get; set; } = 0;
        public int MaxHealth { get; set; } = 0;
        
        public event Action OnChangeHealth;

        public void Heal(int amount)
        {

        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            OnChangeHealth?.Invoke();
        }

        public void SetMaxHealth(int amount)
        {
            if(MaxHealth != 0)
                return;
            CurrentHealth = MaxHealth = amount;
        }

}
}