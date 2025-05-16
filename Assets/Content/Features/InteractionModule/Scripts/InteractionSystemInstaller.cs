using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.InteractionModule {
    public class InteractionSystemInstaller : Installer<InteractionSystemInstaller> {
        public override void InstallBindings() {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            InteractConfiguration interactConfiguration = addressablesAssetLoaderService.LoadAsset<InteractConfiguration>(Address.Configurations.InteractConfiguration);

            Container.Bind<InteractConfiguration>()
                     .FromInstance(interactConfiguration)
                     .AsSingle();
            
            Container.BindInterfacesTo<InteractRaycastSystem>()
                     .AsSingle();
        }
    }
}