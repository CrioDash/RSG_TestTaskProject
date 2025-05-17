using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.MoneyModule.Scripts
{
    public class PlayerMoneyView: UIView
    {
        [SerializeField] private Text moneyText;

        public void SetMoneyAmount(int amount)
        {
            moneyText.text = amount.ToString();
        }
    }
}