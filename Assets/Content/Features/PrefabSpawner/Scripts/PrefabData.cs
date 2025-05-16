using System;
using UnityEngine;

namespace Content.Features.PrefabSpawner {
    [Serializable]
    public struct PrefabData {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject GameObject { get; private set; }

        public PrefabData(string name, GameObject gameObject) {
            Name = name;
            GameObject = gameObject;
        }
    }
}