using System;
using System.Collections.Generic;
using Infrastructure.Services.MessageProvider;
using Infrastructure.Services.UIFactory;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Messages {
    public sealed class MessagesWindow : BaseWindow {
        [SerializeField] RectTransform MessagesRoot;

        readonly List<MessageView> _messageViews = new List<MessageView>();
        
        List<MessageDescription> _messageDescriptions;
        IUIFactory _uiFactory;
        Action<int> _onMessageClicked;

        public void Init(IUIFactory uiFactory, List<MessageDescription> messageDescriptions, Action<int> onMessageClicked) {
            _uiFactory = uiFactory;
            _messageDescriptions = messageDescriptions;

            _onMessageClicked = onMessageClicked;
        }

        public override void Show() {
            CreateViews();
            base.Show();
        }

        public override void Hide(bool tryShowLast = true) {
            ClearViews();
            base.Hide(tryShowLast);
        }

        void CreateViews() {
            foreach (var messageDescription in _messageDescriptions) {
                var messageView = CreateMessageView();
                messageView.Init(messageDescription.Id, messageDescription.Sender, messageDescription.Message, _onMessageClicked);
                _messageViews.Add(messageView);
                
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(MessagesRoot);
        }

        void ClearViews() {
            foreach (var messageView in _messageViews) {
                Destroy(messageView.gameObject);
            }
            _messageViews.Clear();
        }

        MessageView CreateMessageView() => 
            _uiFactory.CreateMessageView(MessagesRoot);
    }
}