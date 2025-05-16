using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    [CreateAssetMenu(menuName = "Configurations/Inventory/" + nameof(ItemsConfiguration), 
        fileName = nameof(ItemsConfiguration) + "_Default", order = 0)]
    public class ItemsConfiguration : ScriptableObject {
        [SerializeField] private List<ItemConfiguration> _configurations;
        [SerializeField] private ItemConfiguration _defaultVisual;

        public ItemConfiguration GetItemConfiguration(ItemType itemType) {
            ItemConfiguration itemConfiguration = _configurations.FirstOrDefault(map => map.ItemType == itemType);
            return itemConfiguration ?? _defaultVisual;
        }
    }
}