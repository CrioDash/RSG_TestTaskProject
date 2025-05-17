using System;
using Content.Features.StorageModule.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Core.UiModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryPresenter: UiPresenter<PlayerInventoryView, PlayerInventoryModel>, IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly IAddressablesAssetLoaderService _loaderService;

        public PlayerInventoryPresenter(
            DiContainer container,
            IAddressablesAssetLoaderService loaderService)
        {
            _container = container;
            _loaderService = loaderService;
        }
        
        public void Initialize()
        {
            Model.OnItemAdded += OnItemAdded;
            Model.OnItemRemoved += OnItemRemoved;
            
            CheckInventoryItems();
        }
        
        public void Dispose()
        {
            Model.OnItemAdded -= OnItemAdded;
            Model.OnItemRemoved -= OnItemRemoved;
        }

        private void CheckInventoryItems()
        {
            foreach (var type in Model.items.Keys)
            {
                GameObject prefab = _loaderService.LoadAsset<GameObject>(Address.UI.PlayerInventoryItemView);

                GameObject go = _container.InstantiatePrefab(prefab, View.transform);

                var itemView = go.GetComponent<PlayerInventoryItemView>();
                itemView.SetItemData(Model.items[type][0].Icon, Model.items[type].Count);
                
                View.ItemViews.Add(type, itemView);
            }
        }
        
        private void OnItemAdded(ItemType type, Item item)
        {
            if(!View.ItemViews.ContainsKey(type))
            {
                GameObject prefab = _loaderService.LoadAsset<GameObject>(Address.UI.PlayerInventoryItemView);

                GameObject go = _container.InstantiatePrefab(prefab, View.transform);

                var itemView = go.GetComponent<PlayerInventoryItemView>();
                itemView.SetItemData(Model.items[type][0].Icon, Model.items[type].Count);
                
                View.ItemViews.Add(type, itemView);
            }
            else
            {
                View.ItemViews[type].SetAmount(Model.items[type].Count);
            }
            
        }

        private void OnItemRemoved(ItemType type, Item item)
        {
            if(!Model.items.ContainsKey(type))
            {
                GameObject.Destroy(View.ItemViews[type].gameObject);
                View.ItemViews.Remove(type);
            }
            else
            {
                View.ItemViews[type].SetAmount(Model.items[type].Count);
            }
        }
        
    }
}