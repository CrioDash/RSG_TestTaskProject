using Zenject;

namespace Core.UiModule.Scripts
{
    public abstract class UiPresenter<T, Tm>: IUiPresenter where T: IUiView where Tm: IUiModel
    {
        [Inject] protected readonly T View;
        [Inject] protected readonly Tm Model;

        public void Show()
        {
            OnShow();
            View.Show();
        }

        public virtual void OnShow()
        {
            
        }

        public void Hide()
        {
            OnHide();
            View.Hide();
        }

        public void OnHide()
        {
            
        }
    }
}