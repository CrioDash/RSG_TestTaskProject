using System.Collections.Generic;
using Content.Features.InventoryModule.Scripts;
using Content.Features.StorageModule.Scripts;
using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.BuyItemModule.Scripts
{
    public class TradeTableView: UIView
    {
        [SerializeField] private List<ItemType> itemTypes;
        [SerializeField] private Transform itemContainer;
        [SerializeField] private Button closeButton;
        
        private Dictionary<ItemType, TradeTableItemView> _tradeItemViews =
            new Dictionary<ItemType, TradeTableItemView>();

        public List<ItemType> ItemTypes => itemTypes;
        public Transform ItemContainer => itemContainer;
        public Button CloseButton => closeButton;
        public Dictionary<ItemType, TradeTableItemView> TradeItemViews => _tradeItemViews;
    }
}