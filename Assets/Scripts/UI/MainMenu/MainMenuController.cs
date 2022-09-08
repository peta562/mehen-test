using Infrastructure.Services.UIFactory;
using Infrastructure.Services.WindowHolder;
using Infrastructure.Services.WindowManager;
using UI.Messages;
using UI.Settings;
using UI.Shop;

namespace UI.MainMenu {
    public sealed class MainMenuController {
        const string BundleName = "MainMenuWindows";

        readonly IUIFactory _uiFactory;
        readonly IWindowHolder _windowHolder;
        readonly SettingsController _settingsController;
        readonly ShopController _shopController;
        readonly MessagesController _messagesController;

        WindowManager _windowManager;
        MainMenuUI _mainMenuUI;

        public MainMenuController(IUIFactory uiFactory, IWindowHolder windowHolder,
            SettingsController settingsController, ShopController shopController,
            MessagesController messagesController) {
            _uiFactory = uiFactory;
            _windowHolder = windowHolder;
            _settingsController = settingsController;
            _shopController = shopController;
            _messagesController = messagesController;
        }

        public void Init() {
            _windowManager = new WindowManager(_windowHolder, BundleName);
            _windowManager.Init();
            
            _settingsController.Init(_windowManager);
            _shopController.Init(_windowManager);
            _messagesController.Init(_windowManager);
            
            _mainMenuUI = _uiFactory.CreateMainMenu();
            _mainMenuUI.Init();
            _mainMenuUI.OnShopButtonClicked += OnShopButtonClicked;
            _mainMenuUI.OnSettingsButtonClicked += OnSettingsButtonClicked;
            _mainMenuUI.OnMessagesButtonClicked += OnMessagesButtonClicked;
        }

        public void DeInit() {
            _mainMenuUI.OnShopButtonClicked -= OnShopButtonClicked;
            _mainMenuUI.OnSettingsButtonClicked -= OnSettingsButtonClicked;
            _mainMenuUI.OnMessagesButtonClicked -= OnMessagesButtonClicked;
            
            _mainMenuUI.DeInit();

            _windowManager.DeInit();
        }

        void OnShopButtonClicked() {
            _shopController.ShowShopWindow();
        }

        void OnSettingsButtonClicked() {
            _settingsController.ShowSettingsWindow();
        }

        void OnMessagesButtonClicked() {
            _messagesController.ShowMessagesWindow();
        }
    }
}