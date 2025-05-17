using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthInstaller: Installer<HealthInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<PlayerHealthModel>()
                .AsSingle();
        }
    }
}