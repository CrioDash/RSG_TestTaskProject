using System;
using System.Linq;
using Content.Features.HealthModule.Scripts;
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
        private readonly PlayerHealthModel _playerHealthModel;

        public PlayerInventoryPresenter(
            DiContainer container,
            IAddressablesAssetLoaderService loaderService,
            PlayerHealthModel playerHealthModel)
        {
            _container = container;
            _loaderService = loaderService;
            _playerHealthModel = playerHealthModel;
        }
        
        public void Initialize()
        {
            Model.OnItemAdded += OnItemAdded;
            Model.OnItemRemoved += OnItemRemoved;
            Model.OnItemsCleared += OnItemsCleared;
            
            CheckInventoryItems();
        }
        
        public void Dispose()
        {
            Model.OnItemAdded -= OnItemAdded;
            Model.OnItemRemoved -= OnItemRemoved;
            Model.OnItemsCleared -= OnItemsCleared;
        }

        private void CheckInventoryItems()
        {
            foreach (var type in Model.items.Keys)
               CreateItem(type);
        }
        
        private void OnItemAdded(ItemType type, Item item)
        {
            if(!View.ItemViews.ContainsKey(type))
                CreateItem(type);
            else
                View.ItemViews[type].SetAmount(Model.items[type].Count);
        }

        private void OnItemRemoved(ItemType type, int amount)
        {
            if (amount == 0)
            {
                GameObject.Destroy(View.ItemViews[type].gameObject);
                View.ItemViews.Remove(type);
            }
            else
                View.ItemViews[type].SetAmount(amount);
        }

        private void OnItemsCleared()
        {
            foreach (var item in View.ItemViews.Keys)
            {
                GameObject.Destroy(View.ItemViews[item].gameObject);
            }
            View.ItemViews.Clear();
        }

        private void CreateItem(ItemType type)
        {
            GameObject prefab = _loaderService.LoadAsset<GameObject>(Address.UI.PlayerInventoryItemView);

            GameObject go = _container.InstantiatePrefab(prefab, View.transform);

            var itemView = go.GetComponent<PlayerInventoryItemView>();
            var isInteractable = type == ItemType.Potion;
            
            if(type == ItemType.Potion)
                itemView.Button.onClick.AddListener(OnPotionClick);
                
            itemView.SetItemData(Model.items[type][0].Icon, Model.items[type].Count, isInteractable);
                
            View.ItemViews.Add(type, itemView);
        }

        private void OnPotionClick()
        {
            Model.RemoveItem(ItemType.Potion, Model.items[ItemType.Potion].Last());
            
            var healAmount = _playerHealthModel.MaxHealth / 4;
            
            _playerHealthModel.PlayerEntity.EntityDamageable.Heal(healAmount);
        }
        
    }
}