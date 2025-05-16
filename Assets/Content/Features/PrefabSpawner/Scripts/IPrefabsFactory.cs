using UnityEngine;

namespace Content.Features.PrefabSpawner {
    public interface IPrefabsFactory {
        public GameObject Create(string prefabName);
        public GameObject Create(string prefabName, Vector3 position);
    }
}