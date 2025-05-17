using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Features.LootModule.Scripts {
    public class LootSpawner : MonoBehaviour {
        [SerializeField] private List<Loot> _lootToSpawn;
        private DiContainer _diContainer;
        private IItemFactory _itemFactory;

        [Inject]
        public void InjectDependencies(DiContainer diContainer, IItemFactory itemFactory)
        {
            _diContainer = diContainer;
            _itemFactory = itemFactory;
        }

        public void SpawnLoot()
        {
            List<float> invertedWeights = _lootToSpawn.Select(i => 1f / i.GetItemsInLoot().Sum(j => _itemFactory.GetItem(j).Price)).ToList();
            
            float totalInverseWeights = invertedWeights.Sum();
            float randomWeight = Random.Range(0, totalInverseWeights);
            float cumulative = 0f;

            var loot = _lootToSpawn.Last();
            
            for(int i = 0; i < _lootToSpawn.Count; i++)
            {
                cumulative += invertedWeights[i];
                if (randomWeight < cumulative)
                {
                    loot = _lootToSpawn[i];
                    break;
                }
            }

            _diContainer.InstantiatePrefab(loot.gameObject, transform.position, Quaternion.identity, null);
        }
    }
}