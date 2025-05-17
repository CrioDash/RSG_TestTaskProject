using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.MoneyModule.Scripts
{
    public class PlayerMoneyView: UIView
    {
        [SerializeField] private Text MoneyText;

        public void SetMoneyAmount(int amount)
        {
            MoneyText.text = amount.ToString();
        }
    }
}