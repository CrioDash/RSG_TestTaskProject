using UnityEngine.EventSystems;

namespace Core.UiModule.Scripts
{
    public abstract class UIView: UIBehaviour, IUiView
    {
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnShow()
        {
            
        }

        protected virtual void OnHide()
        {
            
        }
    }
}