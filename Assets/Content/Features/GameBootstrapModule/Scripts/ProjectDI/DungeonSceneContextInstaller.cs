using Content.Features.PrefabSpawner;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(DungeonSceneContextInstaller),
        fileName = nameof(DungeonSceneContextInstaller) + "_Default", order = 0)]
    public class DungeonSceneContextInstaller : ScriptableObjectInstaller<DungeonSceneContextInstaller> {
        public override void InstallBindings() {
            PrefabSpawnerInstaller.Install(Container);
        }
    }
}