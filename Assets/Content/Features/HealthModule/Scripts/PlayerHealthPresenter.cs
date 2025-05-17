using System;
using Core.UiModule.Scripts;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthPresenter: UiPresenter<PlayerHealthView, PlayerHealthModel>, IInitializable, IDisposable
    {

        public PlayerHealthPresenter()
        {
            
        }
        
        public void Initialize()
        {
            Model.OnChangeHealth += OnChangeHealth;
            
            OnChangeHealth();
        }

        public void Dispose()
        {
            Model.OnChangeHealth -= OnChangeHealth;
        }

        private void OnChangeHealth()
        {
            View.SetFill((float)Model.CurrentHealth/Model.MaxHealth);
        }
        
    }
}