using UnityEngine.EventSystems;

namespace Core.UiModule.Scripts
{
    public abstract class UIView: UIBehaviour, IUiView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}