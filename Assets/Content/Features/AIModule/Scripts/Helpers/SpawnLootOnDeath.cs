using Content.Features.DamageablesModule.Scripts;
using Content.Features.LootModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Entity {
    public class SpawnLootOnDeath : MonoBehaviour {
        [SerializeField] private LootSpawner _lootSpawner;
        private IDamageable _damageable;

        private void Start() {
            _damageable = GetComponent<IDamageable>();
            _damageable.OnKilled += OnKilled;
        }

        private void OnDestroy() {
            _damageable.OnDamaged -= OnKilled;
        }

        private void OnKilled() =>
            _lootSpawner.SpawnLoot();
    }
}