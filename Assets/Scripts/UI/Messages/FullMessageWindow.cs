using System;
using Infrastructure.Services.MessageProvider;
using TMPro;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Messages {
    public sealed class FullMessageWindow : BaseWindow {
        [SerializeField] TMP_Text MessageText;
        [SerializeField] TMP_InputField InputField;
        [SerializeField] Button SendButton;

        Action<string> _onSendReply;

        public void Init(string messageText, Action<string> onSendReply) {
            MessageText.text = messageText;

            _onSendReply = onSendReply;
        }

        public override void Show() {
            SendButton.onClick.AddListener(OnSendButtonClicked);
            base.Show();
        }

        public override void Hide(bool tryShowLast = true) {
            SendButton.onClick.RemoveListener(OnSendButtonClicked);
            base.Hide(tryShowLast);
        }

        void OnSendButtonClicked() {
            _onSendReply?.Invoke(InputField.text);
        }
    }
}