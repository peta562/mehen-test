using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings {
    public sealed class SettingsWindow : BaseWindow {
        [Header("Buttons")]
        [SerializeField] Button SoundButton;
        [SerializeField] Button MusicButton;

        [Header("Button images")] 
        [SerializeField] Image SoundButtonImage;
        [SerializeField] Image MusicButtonImage;
        
        [Header("Button images sprites")]
        [SerializeField] Sprite SoundButtonOnSprite;
        [SerializeField] Sprite SoundButtonOffSprite;

        [SerializeField] Sprite MusicButtonOnSprite;
        [SerializeField] Sprite MusicButtonOffSprite;

        SettingsController _settingsController;

        public void Init(SettingsController settingsController) {
            _settingsController = settingsController;
        }

        public override void Show() {
            SetButtonsImage();
            SoundButton.onClick.AddListener(SoundButtonClicked);
            MusicButton.onClick.AddListener(MusicButtonClicked);
            base.Show();
        }

        public override void Hide(bool tryShowLast = true) {
            SoundButton.onClick.RemoveListener(SoundButtonClicked);
            MusicButton.onClick.RemoveListener(MusicButtonClicked);
            base.Hide(tryShowLast);
        }

        void SoundButtonClicked() {
            _settingsController.ToggleSound();
            SetButtonsImage();
        }

        void MusicButtonClicked() {
            _settingsController.ToggleMusic();
            SetButtonsImage();
        }

        void SetButtonsImage() {
            SoundButtonImage.sprite = _settingsController.SoundOn ? SoundButtonOnSprite : SoundButtonOffSprite;
            MusicButtonImage.sprite = _settingsController.MusicOn ? MusicButtonOnSprite : MusicButtonOffSprite;
        }
    }
}