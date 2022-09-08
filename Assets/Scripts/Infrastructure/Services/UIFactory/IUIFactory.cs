using System.Collections.Generic;
using UI.MainMenu;
using UI.Messages;
using UI.Shop;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.Services.UIFactory {
    public interface IUIFactory : IService {
        List<BaseWindow> CreateWindows(string bundleName, Transform parent);
        WindowBackground CreateWindowBackground(Transform parent);
        Transform CreateWindowsRoot();
        MainMenuUI CreateMainMenu();
        ShopItemView CreateShopItemView(Transform parent);
        MessageView CreateMessageView(Transform parent);
    }
}