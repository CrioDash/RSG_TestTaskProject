using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryItemView: UIView
    {
        [SerializeField] private Image Icon;
        [SerializeField] private Text Amount;

        public void SetItemData(Sprite icon, int amount)
        {
            Icon.sprite = icon;
            Amount.text = amount.ToString();
        }

        public void SetAmount(int amount)
        {
            Amount.text = amount.ToString();
        }
    }
}