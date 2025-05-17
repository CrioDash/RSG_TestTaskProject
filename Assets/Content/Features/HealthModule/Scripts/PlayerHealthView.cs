using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.HealthModule.Scripts
{
    public class PlayerHealthView: UIView
    {
        [SerializeField] private Slider slider;

        public void SetFill(float value)
        {
            slider.value = value;
        }

    }
}