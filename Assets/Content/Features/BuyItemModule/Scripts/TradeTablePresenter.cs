using System;
using Content.Features.InventoryModule.Scripts;
using Content.Features.MoneyModule.Scripts;
using Content.Features.StorageModule.Scripts;
using Core.AssetLoaderModule.Core.Scripts;
using Core.UiModule.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.BuyItemModule.Scripts
{
    public class TradeTablePresenter: UiPresenter<TradeTableView, TradeTableModel>, IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly IAddressablesAssetLoaderService _loaderService;
        private readonly IItemFactory _itemFactory;
        private readonly PlayerMoneyModel _playerMoneyModel;
        private readonly PlayerInventoryModel _playerInventoryModel;

        public TradeTablePresenter(
            DiContainer container,
            IAddressablesAssetLoaderService loaderService,
            IItemFactory itemFactory,
            PlayerMoneyModel playerMoneyModel,
            PlayerInventoryModel playerInventoryModel)
        {
            _container = container;
            _loaderService = loaderService;
            _itemFactory = itemFactory;
            _playerMoneyModel = playerMoneyModel;
            _playerInventoryModel = playerInventoryModel;
        }
        
        public void Initialize()
        {
            View.CloseButton.onClick.AddListener(OnCloseButton);
            
            CreateTradeItems();

            Model.OnChangeState += OnChangeState;
        }
        
        public void Dispose()
        {
            Model.OnChangeState -= OnChangeState;
        }

        private void CreateTradeItems()
        {
            foreach (var itemType in View.ItemTypes)
            {
                GameObject prefab = _loaderService.LoadAsset<GameObject>(Address.UI.TradeTableItemView);

                var tradeItem = _container.InstantiatePrefab(prefab, View.ItemContainer).GetComponent<TradeTableItemView>();

                var item = _itemFactory.GetItem(itemType);

                tradeItem.SetData(item.Icon, item.Price);
                tradeItem.Button.onClick.AddListener( () => BuyItem(item.Price, itemType, item));
            }
        }

        private void OnChangeState(bool isActive)
        {
            if (isActive)
                Show();
            else
                Hide();
        }

        private void OnCloseButton()
        {
            Model.Hide();
        }

        private void BuyItem(int price, ItemType type, Item item)
        {
            if (_playerMoneyModel.Money >= price && !_playerInventoryModel.IsInventoryFull())
            {
                _playerMoneyModel.RemoveMoney(price);
                _playerInventoryModel.AddItem(type, item);
            }
        }
    }
}