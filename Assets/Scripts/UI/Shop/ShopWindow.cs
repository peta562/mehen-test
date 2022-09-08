using System;
using System.Collections.Generic;
using Configs;
using Infrastructure.Services.UIFactory;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Shop {
    public sealed class ShopWindow : BaseWindow {
        [SerializeField] RectTransform ItemsRoot;
        
        IUIFactory _uiFactory;
        List<ShopItemDescription> _itemDescriptions;
        Action<ItemType, int> _buyItem;

        public void Init(IUIFactory uiFactory, List<ShopItemDescription> itemDescriptions, Action<ItemType, int> buyItem) {
            _uiFactory = uiFactory;
            _itemDescriptions = itemDescriptions;

            _buyItem = buyItem;
        }

        public override void Show() {
            CreateViews();
            base.Show();
        }

        void CreateViews() {
            foreach (var itemDescription in _itemDescriptions) {
                var itemView = CreateView();
                itemView.Init(itemDescription.ItemType, itemDescription.ItemSprite, itemDescription.Price, itemDescription.Count, _buyItem);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(ItemsRoot);
        }

        ShopItemView CreateView() => 
            _uiFactory.CreateShopItemView(ItemsRoot);
    }
}