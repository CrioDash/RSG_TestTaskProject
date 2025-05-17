using System;
using Core.UiModule.Scripts;

namespace Content.Features.BuyItemModule.Scripts
{
    public class TradeTableModel: IUiModel
    {
        public event Action<bool> OnChangeState;

        public void Show()
        {
            OnChangeState?.Invoke(true);
        }
        
        public void Hide()
        {
            OnChangeState?.Invoke(false);
        }
    }
}