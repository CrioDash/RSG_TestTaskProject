using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class AIInstaller : Installer<AIInstaller> {
        public override void InstallBindings() {
            Container.Bind<PlayerEntityModel>()
                .AsSingle();
            
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            Container.Bind<EntitiesConfiguration>()
                .FromScriptableObject(addressablesAssetLoaderService.LoadAsset<EntitiesConfiguration>(Address.Configurations.EntitiesConfiguration_Default))
                .AsSingle();

            Container.Bind<IEntityBehaviourFactory>()
                .To<EntityBehaviourFactory>()
                .AsSingle();
            
            Container.Bind<IEntityDataService>()
                .To<EntityDataService>()
                .AsSingle();
        }
    }
}