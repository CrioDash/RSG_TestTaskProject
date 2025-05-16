using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryModel
    {
        public List<Item> items { get; private set; } = new List<Item>();
        
        public void AddItem(Item item) => 
            items.Add(item);

        public void RemoveItem(Item item) =>
            items.Remove(item);
        
        public bool HasItem(Item item)
        {
            return items.Contains(item);
        }

    }
}