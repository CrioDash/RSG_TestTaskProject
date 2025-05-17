using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using Core.UiModule.Scripts;
using UnityEngine;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryView: UIView
    {
        [SerializeField] private PlayerInventoryItemView _itemView;
        
        private Dictionary<ItemType, PlayerInventoryItemView> itemViews =
            new Dictionary<ItemType, PlayerInventoryItemView>();

        public Dictionary<ItemType, PlayerInventoryItemView> ItemViews => itemViews;
        public PlayerInventoryItemView ItemView => _itemView;
    }
}