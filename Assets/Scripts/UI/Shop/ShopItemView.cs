using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Shop {
    public sealed class ShopItemView : MonoBehaviour {
        [SerializeField] Image ItemIcon;
        [SerializeField] TMP_Text PriceText;
        [SerializeField] TMP_Text CountText;
        [SerializeField] Button BuyButton;

        Action<ItemType, int> _buyButtonClicked;
        
        ItemType _itemType;
        int _count;
        
        public void Init(ItemType itemType, Sprite itemSprite, string price, int count, Action<ItemType, int> buyButtonClicked) {
            ItemIcon.sprite = itemSprite;
            PriceText.text = price;
            CountText.text = count.ToString();

            _count = count;
            _itemType = itemType;

            _buyButtonClicked = buyButtonClicked;
            
            BuyButton.onClick.AddListener(OnBuyButtonClicked);
        }

        void OnBuyButtonClicked() {
            _buyButtonClicked?.Invoke(_itemType, _count);
        }
    }
}