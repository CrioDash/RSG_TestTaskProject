using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthView: UIView
    {
        [SerializeField] private Slider _slider;

        public void SetFill(float value)
        {
            _slider.value = value;
        }

    }
}