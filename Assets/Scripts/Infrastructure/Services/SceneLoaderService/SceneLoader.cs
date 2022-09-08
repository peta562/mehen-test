using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoaderService {
    public sealed class SceneLoader : ISceneLoader {
        readonly ICoroutineRunner _coroutineRunner;
        readonly LoadingScreen _loadingScreen;

        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen) {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;
        }

        public void Load(SceneName sceneName, Action onLoaded = null) {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        IEnumerator LoadScene(SceneName sceneName, Action onLoaded = null) {
            _loadingScreen.Show();

            var nextSceneName = sceneName.ToString();

            if ( SceneManager.GetActiveScene().name == nextSceneName ) {
                onLoaded?.Invoke();
                yield break;
            }

            var nextScene = SceneManager.LoadSceneAsync(nextSceneName);

            while ( !nextScene.isDone ) {
                yield return null;
            }

            _loadingScreen.Hide();
            onLoaded?.Invoke();
        }
    }
}