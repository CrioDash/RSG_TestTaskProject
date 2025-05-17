using Content.Features.AIModule.Scripts.Entity;
using Content.Features.StorageModule.Scripts;
using Content.Features.CameraModule;
using Content.Features.CanvasModule.Scripts;
using Content.Features.HealthModule.Scripts;
using Content.Features.InteractionModule;
using Content.Features.InventoryModule.Scripts;
using Content.Features.LootModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.PrefabSpawner;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(GlobalSceneContextInstaller),
        fileName = nameof(GlobalSceneContextInstaller) + "_Default", order = 0)]
    public class GlobalSceneContextInstaller : ScriptableObjectInstaller<GlobalSceneContextInstaller> {
        public override void InstallBindings() {
            CanvasInstaller.Install(Container);
            PrefabSpawnerInstaller.Install(Container);
            PlayerDataInstaller.Install(Container);
            CameraInstaller.Install(Container);
            StorageModuleInstaller.Install(Container);
            InteractionSystemInstaller.Install(Container);
            AIInstaller.Install(Container);
            LootInstaller.Install(Container);
            InventoryInstaller.Install(Container);
            HealthInstaller.Install(Container);
        }
    }
}