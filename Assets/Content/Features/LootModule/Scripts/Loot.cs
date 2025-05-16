using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.LootModule.Scripts {
    public class Loot : MonoBehaviour {
        [SerializeField] private List<ItemType> _itemsInLoot;
    
        public List<ItemType> GetItemsInLoot() =>
            _itemsInLoot;

        public void DestroyLoot() =>
            Destroy(gameObject);
    }
}