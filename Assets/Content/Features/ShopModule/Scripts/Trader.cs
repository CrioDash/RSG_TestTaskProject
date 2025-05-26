using System.Collections.Generic;
using System.Linq;
using Content.Features.InventoryModule.Scripts;
using Content.Features.MoneyModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.ShopModule.Scripts {
    public class Trader : MonoBehaviour
    {

        [Inject] private PlayerInventoryModel _playerInventoryModel;
        [Inject] private PlayerMoneyModel _playerMoneyModel;
        
        public int SellAllItemsFromStorage(IStorage storage)
        {
            if (storage.GetAllItems().Count == 0)
                return 0;
            
            int sumOfMoney = 0;
            foreach (int price in storage.GetAllItems().Select(item => item.Price))
                sumOfMoney += price;
            
            _playerInventoryModel.RemoveAllItems();
            _playerMoneyModel.AddMoney(sumOfMoney);
            
            return sumOfMoney;
        }

        public int SellItemFromStorage(Item item, IStorage storage) {
            storage.RemoveItem(item);

            return item.Price;
        }

        public int SellItemsFromStorage(List<Item> items, IStorage storage) {
            storage.RemoveItems(items);

            int sumOfMoney = 0;
            foreach (int price in items.Select(item => item.Price))
                sumOfMoney += price;

            return sumOfMoney;
        }
    }
}
