using System;
using Infrastructure.Services.UIFactory;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows {
    public abstract class BaseWindow : MonoBehaviour {
        [SerializeField] Button CloseButton;
        
        Action<bool> _onHideAction;

        public void Init(Action<bool> onHideAction) {
	        _onHideAction = onHideAction;
	        CloseButton.onClick.AddListener(OnCloseButtonClicked);
        }

        public void DeInit() {
	        _onHideAction = null;
	        CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
        }
        
        public virtual void Show() {
	        gameObject.SetActive(true);
        }

        public virtual void Hide(bool tryShowLast = true) {
	        gameObject.SetActive(false);
	        _onHideAction?.Invoke(tryShowLast);
        }

        void OnCloseButtonClicked() {
	        Hide();
        }
    }
}