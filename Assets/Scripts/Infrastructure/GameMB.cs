using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.ConfigProvider;
using Infrastructure.Services.MessageProvider;
using Infrastructure.Services.SceneLoaderService;
using Infrastructure.Services.UIFactory;
using Infrastructure.Services.WindowHolder;
using UnityEngine;

namespace Infrastructure {
    public sealed class GameMB : MonoBehaviour, ICoroutineRunner {
        [SerializeField] LoadingScreen LoadingScreenPrefab;

        ServiceLocator _services;

        void Awake() {
            CreateServices();

            GameState.TryCreate(_services);

            DontDestroyOnLoad(this);
        }

        void Start() {
            LoadMainMenuScene();
        }

        void CreateServices() {
            _services = new ServiceLocator();
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(this, Instantiate(LoadingScreenPrefab)));
            
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IConfigProvider>(new ResourcesConfigProvider());
            _services.RegisterSingle<IMessageProvider>(new MockMessageProvider());
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IWindowHolder>(new WindowHolder(_services.Single<IUIFactory>()));
        }

        void LoadMainMenuScene() {
            _services.Single<ISceneLoader>().Load(SceneName.MainMenu);
        }
    }
}