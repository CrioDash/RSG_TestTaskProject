﻿using Zenject;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryInstaller: Installer<InventoryInstaller>
    {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<PlayerInventoryModel>()
                .AsSingle();
        }
    }
}