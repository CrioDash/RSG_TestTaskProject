using Core.AssetLoaderModule.Core.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.PrefabSpawner {
    public class PrefabsFactory : IPrefabsFactory {
        private readonly IAddressablesAssetLoaderService _addressablesAssetLoaderService;
        private readonly DiContainer _diContainer;

        public PrefabsFactory(IAddressablesAssetLoaderService addressablesAssetLoaderService, DiContainer diContainer) {
            _addressablesAssetLoaderService = addressablesAssetLoaderService;
            _diContainer = diContainer;
        }

        public GameObject Create(string prefabName) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab);
        }

        public GameObject Create(string prefabName, Vector3 position) {
            GameObject prefab = _addressablesAssetLoaderService.LoadAsset<GameObject>(prefabName);
            return _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
        }
    }
}