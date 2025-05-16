using Content.Features.PrefabSpawner;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(SurfaceSceneContextInstaller),
        fileName = nameof(SurfaceSceneContextInstaller) + "_Default", order = 0)]
    public class SurfaceSceneContextInstaller : ScriptableObjectInstaller<SurfaceSceneContextInstaller> {
        public override void InstallBindings() {
            PrefabSpawnerInstaller.Install(Container);
        }
    }
}