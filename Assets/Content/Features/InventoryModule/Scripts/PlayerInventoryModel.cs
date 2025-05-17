using System;
using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using Core.UiModule.Scripts;
using UnityEngine;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryModel: IUiModel
    {
        public Dictionary<ItemType, List<Item>> items { get; private set; } = new Dictionary<ItemType, List<Item>>();
        
        public event Action<ItemType, Item> OnItemAdded;
        public event Action<ItemType, Item> OnItemRemoved;
        
        public void AddItem(ItemType itemType, Item item)
        {
            Debug.Log($"Model Item Added: {itemType}");
            
            if(!HasItem(itemType))
                items.Add(itemType, new List<Item>());
            items[itemType].Add(item);

            OnItemAdded?.Invoke(itemType, item);
        }

        public void RemoveItem(ItemType itemType, Item item)
        {
            if(!HasItem(itemType))
                return;
            items[itemType].Remove(item);
            if (items[itemType].Count == 0)
                items.Remove(itemType);
            
            OnItemRemoved?.Invoke(itemType, item);
        }
        
        public bool HasItem(ItemType item)
        {
            return items.ContainsKey(item);
        }

    }
}