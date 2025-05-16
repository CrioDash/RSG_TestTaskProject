using System;
using System.Collections.Generic;
using System.Linq;

namespace Content.Features.StorageModule.Scripts {
    public class StandardStorage : IStorage {
        private List<Item> _items = new List<Item>();

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public List<Item> GetAllItems() =>
            _items.ToList();

        public void AddItem(Item item) {
            if(_items.Contains(item))
                return;
        
            _items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item) {
            if(_items.Contains(item) is false)
                return;

            _items.Remove(item);
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            foreach (Item item in _items)
                RemoveItem(item);
        }
    }
}