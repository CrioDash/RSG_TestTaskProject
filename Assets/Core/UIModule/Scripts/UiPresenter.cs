using UnityEngine;
using Zenject;

namespace Core.UiModule.Scripts
{
    public abstract class UiPresenter<T, Tm>: IUiPresenter where T: IUiView where Tm: IUiModel
    {
        [Inject] protected readonly T View;
        [Inject] protected readonly Tm Model;

        public void Show()
        {
            View.Show();
        }

        public void Hide()
        {
            View.Hide();
        }
    }
}