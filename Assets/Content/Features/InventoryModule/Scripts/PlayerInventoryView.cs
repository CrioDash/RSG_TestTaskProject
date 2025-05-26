using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using Core.UiModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryView: UIView
    {
        private Dictionary<ItemType, PlayerInventoryItemView> _itemViews =
            new Dictionary<ItemType, PlayerInventoryItemView>();

        public Dictionary<ItemType, PlayerInventoryItemView> ItemViews => _itemViews;
    }
}