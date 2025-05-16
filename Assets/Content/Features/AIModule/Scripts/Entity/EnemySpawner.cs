using Content.Features.PrefabSpawner;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.LootModule.Scripts {
    public class EnemySpawner : MonoBehaviour {
        private IPrefabsFactory _prefabsFactory;

        [Inject]
        public void InjectDependencies( IPrefabsFactory prefabsFactory) {
            _prefabsFactory = prefabsFactory;
        }

        private void Start() =>
            _prefabsFactory.Create(Address.Prefabs.Standard_Enemy, transform.position);
    }
}