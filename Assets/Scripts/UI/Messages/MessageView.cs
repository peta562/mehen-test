using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Messages {
    public sealed class MessageView : MonoBehaviour {
        [SerializeField] TMP_Text SenderText;
        [SerializeField] TMP_Text PreviewText;
        [SerializeField] Button MessageButton;

        int _id;
        Action<int> _messageButtonClicked;

        public void Init(int id, string sender, string previewMessage, Action<int> messageButtonClicked) {
            _id = id;
            SenderText.text = sender;
            PreviewText.text = previewMessage;

            _messageButtonClicked = messageButtonClicked;
            
            MessageButton.onClick.AddListener(OnMessageButtonClicked);
        }

        void OnMessageButtonClicked() {
            _messageButtonClicked?.Invoke(_id);
        }
    }
}