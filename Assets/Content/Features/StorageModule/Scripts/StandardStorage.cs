﻿using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.InventoryModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.StorageModule.Scripts {
    public class StandardStorage : IStorage {
        private List<Item> _items = new List<Item>();

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public List<Item> GetAllItems() =>
            _items.ToList();

        public void AddItem(Item item) {
            _items.Add(item);
            
            OnItemAdded?.Invoke(item);
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item) {
            if(!_items.Contains(item))
                return;

            _items.Remove(item);
            
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            _items.Clear();
        }
    }
}