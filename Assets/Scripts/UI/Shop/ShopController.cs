using System.Collections.Generic;
using Configs;
using Infrastructure.Services.UIFactory;
using Infrastructure.Services.WindowManager;
using UnityEngine;

namespace UI.Shop {
    public sealed class ShopController {
        List<ShopItemDescription> _items;

        readonly ShopConfig _shopConfig;
        readonly IUIFactory _uiFactory;

        WindowManager _windowManager;

        public ShopController(IUIFactory uiFactory, ShopConfig shopConfig) {
            _uiFactory = uiFactory;
            _shopConfig = shopConfig;
        }

        public void Init(WindowManager windowManager) {
            _windowManager = windowManager;
            _items = _shopConfig.ShopItemDescriptions;
        }

        public void ShowShopWindow() {
            _windowManager.ShowWindow<ShopWindow>(x => x.Init(_uiFactory, _items, BuyItem));
        }

        void BuyItem(ItemType itemType, int count) {
            foreach (var item in _items) {
                if ( (item.ItemType == itemType) && item.Count == count ) {
                    Debug.Log($"Buy item {item.ItemType}, price: {item.Price}, count: {item.Count}");
                    return;
                }
            }
            Debug.LogError($"Can't buy item {itemType} with count: {count}");
        }
    }
}