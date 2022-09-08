using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu {
    public sealed class MainMenuUI : MonoBehaviour {
        public event Action OnShopButtonClicked;
        public event Action OnSettingsButtonClicked;
        public event Action OnMessagesButtonClicked;
        
        [SerializeField] Button ShopButton;
        [SerializeField] Button SettingsButton;
        [SerializeField] Button MessagesButton;
        
        public void Init() {
            ShopButton.onClick.AddListener(ShopButtonClicked);
            SettingsButton.onClick.AddListener(SettingsButtonClicked);
            MessagesButton.onClick.AddListener(MessagesButtonClicked);
        }

        public void DeInit() {
            ShopButton.onClick.RemoveListener(ShopButtonClicked);
            SettingsButton.onClick.RemoveListener(SettingsButtonClicked);
            MessagesButton.onClick.RemoveListener(MessagesButtonClicked);
        }

        void ShopButtonClicked() {
            OnShopButtonClicked?.Invoke();
        }

        void SettingsButtonClicked() {
            OnSettingsButtonClicked?.Invoke();
        }

        void MessagesButtonClicked() {
            OnMessagesButtonClicked?.Invoke();
        }
    }
}