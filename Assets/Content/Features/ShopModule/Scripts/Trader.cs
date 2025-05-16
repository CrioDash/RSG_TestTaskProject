using System.Collections.Generic;
using System.Linq;
using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.ShopModule.Scripts {
    public class Trader : MonoBehaviour {
        public int SellAllItemsFromStorage(IStorage storage) {
            int sumOfMoney = 0;
            foreach (int price in storage.GetAllItems().Select(item => item.Price))
                sumOfMoney += price;

            storage.RemoveAllItems();
            Debug.LogError("Recieved " + sumOfMoney);
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
