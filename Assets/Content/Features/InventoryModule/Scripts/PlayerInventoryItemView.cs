using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryItemView: UIView
    {
        [SerializeField] private Text amount;
        [SerializeField] private Button button;

        public Button Button => button;

        public void SetItemData(Sprite icon, int amount, bool isClickable)
        {
            button.image.sprite = icon;
            button.interactable = isClickable;
            this.amount.text = amount.ToString();
        }

        public void SetAmount(int amount)
        {
            this.amount.text = amount.ToString();
        }
    }
}