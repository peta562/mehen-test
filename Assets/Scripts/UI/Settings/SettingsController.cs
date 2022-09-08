using Infrastructure.Services.WindowManager;
using UI.Shop;

namespace UI.Settings {
    public sealed class SettingsController {
        public bool SoundOn { get; private set; }
        public bool MusicOn { get; private set; }

        WindowManager _windowManager;

        public void Init(WindowManager windowManager) {
            _windowManager = windowManager;
            
            SoundOn = true;
            MusicOn = true;
        }

        public void ShowSettingsWindow() {
            _windowManager.ShowWindow<SettingsWindow>(x => x.Init(this));
        }

        public void ToggleSound() {
            SoundOn = !SoundOn;
        }

        public void ToggleMusic() {
            MusicOn = !MusicOn;
        }
    }
}