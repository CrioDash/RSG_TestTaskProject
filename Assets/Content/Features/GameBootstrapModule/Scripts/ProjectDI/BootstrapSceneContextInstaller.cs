using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(BootstrapSceneContextInstaller),
        fileName = nameof(BootstrapSceneContextInstaller) + "_Default", order = 0)]
    public class BootstrapSceneContextInstaller : ScriptableObjectInstaller<BootstrapSceneContextInstaller> {
        public override void InstallBindings() { }
    }
}