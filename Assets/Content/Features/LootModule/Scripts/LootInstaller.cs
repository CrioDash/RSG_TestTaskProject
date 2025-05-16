using Zenject;

namespace Content.Features.LootModule.Scripts {
    public class LootInstaller : Installer<LootInstaller> {
        public override void InstallBindings() {
            Container.Bind<ILootService>()
                .To<LootService>()
                .AsSingle();
        }
    }
}