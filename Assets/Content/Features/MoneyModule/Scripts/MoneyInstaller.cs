using Zenject;

namespace Content.Features.MoneyModule.Scripts
{
    public class MoneyInstaller: Installer<MoneyInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<PlayerMoneyModel>()
                .AsSingle();
        }
    }
}