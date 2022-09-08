using UnityEngine;

namespace Infrastructure {
    public class LoadingScreen : MonoBehaviour{
        void Awake() {
            DontDestroyOnLoad(this);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}