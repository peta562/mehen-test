using Configs;

namespace Infrastructure.Services.ConfigProvider {
    public sealed class ConfigsHolder {
        public ShopConfig ShopConfig { get; private set; }

        readonly IConfigProvider _configProvider;

        public ConfigsHolder(IConfigProvider configProvider) {
            _configProvider = configProvider;
        }
        
        public void LoadConfigs() {
            ShopConfig = _configProvider.LoadConfig<ShopConfig>(ConfigsPath.ShopConfigPath);
        }
    }
}