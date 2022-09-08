using Infrastructure;
using UnityEngine;

namespace Starters {
    public sealed class MainMenuStarter : MonoBehaviour {
        void Awake() {
            var gameState = GameState.Instance;

            var mainMenuController = gameState.MainMenuController;

            mainMenuController.Init();
        }
    }
}