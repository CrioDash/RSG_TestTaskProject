using Zenject;

namespace Content.Features.PlayerData.Scripts {
    public class PlayerDataInstaller : Installer<PlayerDataInstaller> {
        public override void InstallBindings() {
            Container.Bind<PlayerTransformModel>()
                     .AsSingle();
        }
    }
}