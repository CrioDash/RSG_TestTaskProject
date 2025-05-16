using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.StorageModule.Scripts {
    public class Item {
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }
        public int Weight { get; private set; }

        public Item(string name, Sprite icon, int price, int weight) {
            Name = name;
            Icon = icon;
            Price = price;
            Weight = weight;
        }
    
        public Item(ItemConfiguration itemConfiguration) {
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            Price = itemConfiguration.Price;
            Weight = itemConfiguration.Weight;
        }
    }
}