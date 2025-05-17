using Content.Features.CanvasModule.Scripts;
using Content.Features.HealthModule.Scripts;
using Content.Features.InventoryModule.Scripts;
using Content.Features.PrefabSpawner;
using Core.AssetLoaderModule.Core.Scripts;
using Core.UiModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(DungeonSceneContextInstaller),
        fileName = nameof(DungeonSceneContextInstaller) + "_Default", order = 0)]
    public class DungeonSceneContextInstaller : ScriptableObjectInstaller<DungeonSceneContextInstaller> {
        
        [Inject] private CanvasModel _canvasRegister;
        
        public override void InstallBindings() {
            PrefabSpawnerInstaller.Install(Container);
            
            BindUI();
        }
        
        private void BindUI()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            
            GameObject canvasPrefab = addressablesAssetLoaderService.LoadAsset<GameObject>(Address.UI.Canvas);
            Canvas canvas = Container.InstantiatePrefab(canvasPrefab).GetComponent<Canvas>();
            
            Container.BindUiView<PlayerInventoryPresenter, PlayerInventoryView>(Address.UI.PlayerInventoryView,
                addressablesAssetLoaderService, canvas.transform, true);
            Container.BindUiView<PlayerHealthPresenter, PlayerHealthView>(Address.UI.PlayerHealthView,
                addressablesAssetLoaderService, canvas.transform, true);
        }
    }
}