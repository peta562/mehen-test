using System;

namespace Infrastructure.Services.SceneLoaderService {
    public interface ISceneLoader : IService {
        void Load(SceneName sceneName, Action onLoaded = null);
    }
}