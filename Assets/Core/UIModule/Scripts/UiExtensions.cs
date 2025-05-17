using Core.AssetLoaderModule.Core.Scripts;
using UnityEngine;
using Zenject;

namespace Core.UiModule.Scripts
{
    public static class UiBindExtensions
    {
        public static void BindUiView<TPresenter, TView>(
            this DiContainer container,
            string prefabName,
            IAddressablesAssetLoaderService loaderService,
            Transform parent, bool isVisible)
            where TPresenter : IUiPresenter, IInitializable
            where TView : IUiView
        {
           
            GameObject prefab = loaderService.LoadAsset<GameObject>(prefabName);
            GameObject go = container.InstantiatePrefab(prefab, parent);

            var viewComponent = go.GetComponent<TView>();

            container.BindInterfacesAndSelfTo<TView>().FromInstance(viewComponent).AsSingle();
            container.BindInterfacesAndSelfTo<TPresenter>().AsSingle().NonLazy();

            go.SetActive(isVisible);
        }
    }
}