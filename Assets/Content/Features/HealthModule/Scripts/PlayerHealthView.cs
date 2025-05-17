using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthView: UIView
    {
        [SerializeField] private Slider Slider;

        public void SetFill(float value)
        {
            Slider.value = value;
        }

    }
}