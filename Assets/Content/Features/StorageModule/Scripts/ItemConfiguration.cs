using System;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.StorageModule.Scripts {
    [Serializable]
    public class ItemConfiguration {
        public ItemType ItemType;
        public string Name;
        public Sprite Icon;
        public int Price;
    }
}