using System;
using Core.UiModule.Scripts;
using Unity.VisualScripting;

namespace Content.Features.MoneyModule.Scripts
{
    public class PlayerMoneyModel: IUiModel
    {
        public int Money { get; set; } = 0;

        public event Action OnMoneyChange;

        public void AddMoney(int amount)
        {
            Money += amount;
            OnMoneyChange?.Invoke();
        }

        public void RemoveMoney(int amount)
        {
            Money -= amount;
            OnMoneyChange?.Invoke();
        }
        
    }
}