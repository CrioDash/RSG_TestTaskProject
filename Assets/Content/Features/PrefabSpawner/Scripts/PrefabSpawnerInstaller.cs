using Zenject;

namespace Content.Features.PrefabSpawner {
    public class PrefabSpawnerInstaller : Installer<PrefabSpawnerInstaller> {
        public override void InstallBindings() {
            Container.BindInterfacesTo<PrefabsFactory>()
                     .AsSingle();
        }
    }
}