using System;
using Core.UiModule.Scripts;
using Zenject;

namespace Content.Features.MoneyModule.Scripts
{
    public class PlayerMoneyPresenter: UiPresenter<PlayerMoneyView, PlayerMoneyModel>, IInitializable, IDisposable
    {
        public void Initialize()
        {
            Model.OnMoneyChange += OnMoneyChange;
            
            OnMoneyChange();
        }

        public void Dispose()
        {
            Model.OnMoneyChange -= OnMoneyChange;
        }

        private void OnMoneyChange()
        {
            View.SetMoneyAmount(Model.Money);
        }
    }
}