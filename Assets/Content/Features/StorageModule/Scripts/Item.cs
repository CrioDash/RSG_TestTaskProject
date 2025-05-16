using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.StorageModule.Scripts {
    public class Item {
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }

        public Item(string name, Sprite icon, int price) {
            Name = name;
            Icon = icon;
            Price = price;
        }
    
        public Item(ItemConfiguration itemConfiguration) {
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            Price = itemConfiguration.Price;
        }
    }
}