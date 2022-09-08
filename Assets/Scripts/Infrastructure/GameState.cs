using Infrastructure.Services;
using Infrastructure.Services.ConfigProvider;
using Infrastructure.Services.MessageProvider;
using Infrastructure.Services.UIFactory;
using Infrastructure.Services.WindowHolder;
using UI.MainMenu;
using UI.Messages;
using UI.Settings;
using UI.Shop;

namespace Infrastructure {
    public sealed class GameState {
        public static GameState Instance { get; private set; }
        
        readonly ServiceLocator _services;
        readonly ConfigsHolder _configsHolder;
        
        public MainMenuController MainMenuController { get; private set; }
        public ShopController ShopController { get; private set; }
        public SettingsController SettingsController { get; private set; }
        public MessagesController MessagesController { get; private set; }
        

        public GameState(ServiceLocator services) {
            _services = services;
            
            _configsHolder = new ConfigsHolder(_services.Single<IConfigProvider>());
            LoadConfigs();
            InitControllers();
        }

        void LoadConfigs() {
            _configsHolder.LoadConfigs();
        }

        void InitControllers() {
            SettingsController = new SettingsController();
            ShopController = new ShopController(_services.Single<IUIFactory>(), _configsHolder.ShopConfig);
            MessagesController = new MessagesController(_services.Single<IUIFactory>(), _services.Single<IMessageProvider>());
            MainMenuController = new MainMenuController(_services.Single<IUIFactory>(),
                _services.Single<IWindowHolder>(), SettingsController, ShopController, MessagesController);
        }

        public static GameState TryCreate(ServiceLocator services) {
            if ( Instance == null ) {
                Instance = new GameState(services);
            }
            return Instance;
        }
    }
}