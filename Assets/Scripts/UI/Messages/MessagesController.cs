using System.Collections.Generic;
using Infrastructure.Services.MessageProvider;
using Infrastructure.Services.UIFactory;
using Infrastructure.Services.WindowManager;
using UnityEngine;

namespace UI.Messages {
    public sealed class MessagesController {
        List<MessageDescription> _messages;

        readonly IUIFactory _uiFactory;
        readonly IMessageProvider _messageProvider;
        WindowManager _windowManager;

        public MessagesController(IUIFactory uiFactory, IMessageProvider messageProvider) {
            _uiFactory = uiFactory;
            _messageProvider = messageProvider;
        }

        public void Init(WindowManager windowManager) {
            _windowManager = windowManager;
            _messages = _messageProvider.GetMessages();
        }

        public void ShowMessagesWindow() {
            _windowManager.ShowWindow<MessagesWindow>(x => x.Init(_uiFactory, _messages, OnMessageClicked));
        }

        void OnMessageClicked(int id) {
            var message = GetMessageById(id);
            if ( message == null ) {
                Debug.LogError($"Can't find message for id: {id}");
                return;
            }

            _windowManager.ShowWindow<FullMessageWindow>(x => x.Init(message.Message, SendReply));
        }

        void SendReply(string message) {
            Debug.Log($"Send message {message}");
        }

        MessageDescription GetMessageById(int id) {
            foreach (var message in _messages) {
                if ( message.Id == id ) {
                    return message;
                }
            }

            return null;
        }
    }
}