using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.LootModule.Scripts;
using Content.Features.StorageModule.Scripts;
using Core.UiModule.Scripts;
using UnityEngine;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryModel: IUiModel
    {
        public Dictionary<ItemType, List<Item>> items { get; private set; } = new Dictionary<ItemType, List<Item>>();
        
        public event Action<ItemType, Item> OnItemAdded;
        public event Action<ItemType, int> OnItemRemoved;
        public event Action OnItemsCleared;
        
        public EntityContext PlayerEntity;
        
        public void AddItem(ItemType itemType, Item item)
        {
            if(!HasItem(itemType))
                items.Add(itemType, new List<Item>());
            items[itemType].Add(item);

            PlayerEntity.Storage.AddItem(item);

            OnItemAdded?.Invoke(itemType, item);
        }

        public void RemoveItem(ItemType itemType, Item item)
        {
            if(!HasItem(itemType))
                return;
            items[itemType].Remove(item);
            
            OnItemRemoved?.Invoke(itemType, items[itemType].Count);
            
            PlayerEntity.Storage.RemoveItem(item);
            
            if (items[itemType].Count == 0)
                items.Remove(itemType);
        }

        public void RemoveAllItems()
        {
            items.Clear();
            PlayerEntity.Storage.RemoveAllItems();
            OnItemsCleared?.Invoke();
        }
        
        public bool HasItem(ItemType item)
        {
            return items.ContainsKey(item);
        }

        public bool IsInventoryFull(int lootWeight)
        {
            int totalWeight = items.SelectMany(pair => pair.Value).Sum(item => item.Weight) + lootWeight;
            return totalWeight > PlayerEntity.EntityData.MaxInventoryWeight;
        }
    }
}