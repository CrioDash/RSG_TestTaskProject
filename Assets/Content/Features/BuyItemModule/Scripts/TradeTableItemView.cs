using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.BuyItemModule.Scripts
{
    public class TradeTableItemView: UIView
    {
        [SerializeField] private Button button;
        [SerializeField] private Text priceText;

        public Button Button => button;

        public void SetData(Sprite icon, int price)
        {
            button.image.sprite = icon;
            priceText.text = price.ToString();
        }
    }
}