using Zenject;

namespace Content.Features.BuyItemModule.Scripts
{
    public class TradeTableInstaller: Installer<TradeTableInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<TradeTableModel>()
                .AsSingle();
        }
    }
}