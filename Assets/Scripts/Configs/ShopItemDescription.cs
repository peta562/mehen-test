using System;
using UI.Shop;
using UnityEngine;

namespace Configs {
    [Serializable]
    public class ShopItemDescription {
        public ItemType ItemType;
        public Sprite ItemSprite;
        public string Price;
        public int Count;
    }
}