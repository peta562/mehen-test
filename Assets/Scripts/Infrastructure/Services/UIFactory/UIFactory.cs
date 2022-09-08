using System.Collections.Generic;
using Infrastructure.Services.AssetManagement;
using UI.MainMenu;
using UI.Messages;
using UI.Shop;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.Services.UIFactory {
    public sealed class UIFactory : IUIFactory {
        readonly IAssetProvider _assetProvider;

        public UIFactory(IAssetProvider assetProvider) {
            _assetProvider = assetProvider;
        }

        public List<BaseWindow> CreateWindows(string bundleName, Transform parent) {
            var windowObjects = _assetProvider.InstantiateAll(bundleName, parent);

            var windows = new List<BaseWindow>();
            foreach (var windowObject in windowObjects) {
                windows.Add(windowObject.GetComponent<BaseWindow>());
            }

            return windows;
        }

        public WindowBackground CreateWindowBackground(Transform parent) =>
            _assetProvider.Instantiate(AssetPath.WindowBackgroundPath, parent).GetComponent<WindowBackground>();


        public Transform CreateWindowsRoot() =>
            _assetProvider.Instantiate(AssetPath.UIRootPath).transform;

        public MainMenuUI CreateMainMenu() =>
            _assetProvider.Instantiate(AssetPath.MainMenuUIPath).GetComponent<MainMenuUI>();

        public ShopItemView CreateShopItemView(Transform parent) =>
            _assetProvider.Instantiate(AssetPath.ShopItemViewPath, parent).GetComponent<ShopItemView>();

        public MessageView CreateMessageView(Transform parent) =>
            _assetProvider.Instantiate(AssetPath.MessageViewPath, parent).GetComponent<MessageView>();
    }
}