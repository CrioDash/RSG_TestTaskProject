﻿using Content.Features.BuyItemModule.Scripts;
using Content.Features.HealthModule.Scripts;
using Content.Features.InventoryModule.Scripts;
using Content.Features.MoneyModule.Scripts;
using Content.Features.PrefabSpawner;
using Core.AssetLoaderModule.Core.Scripts;
using Core.UiModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.ProjectDI {
    [CreateAssetMenu(menuName = "Configurations/GameBootstrap/" + nameof(SurfaceSceneContextInstaller),
        fileName = nameof(SurfaceSceneContextInstaller) + "_Default", order = 0)]
    public class SurfaceSceneContextInstaller : ScriptableObjectInstaller<SurfaceSceneContextInstaller>
    {
        
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
            Container.BindUiView<PlayerMoneyPresenter, PlayerMoneyView>(Address.UI.PlayerMoneyView,
                addressablesAssetLoaderService, canvas.transform, true);
            Container.BindUiView<TradeTablePresenter, TradeTableView>(Address.UI.TradeTableView,
                addressablesAssetLoaderService, canvas.transform, false);
        }
        
        
        
    }
}