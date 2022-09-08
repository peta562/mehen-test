using System;
using System.Collections.Generic;
using Infrastructure.Services.WindowHolder;
using UI.Windows;

namespace Infrastructure.Services.WindowManager {
    public sealed class WindowManager {
        readonly Stack<BaseWindow> _activeWindows = new Stack<BaseWindow>();
        readonly IWindowHolder _windowHolder;
        readonly string _bundleName;
        
        List<BaseWindow> _windows;
        WindowBackground _windowBackground;
        BaseWindow _currentWindow;

        public WindowManager(IWindowHolder windowHolder, string bundleName) {
            _windowHolder = windowHolder;
            _bundleName = bundleName;
        }
        
        public void Init() {
            _windowHolder.CreateWindowsRoot();
            
            _windowBackground = _windowHolder.GetWindowBackground();
            _windowBackground.Hide();
            
            _windows = _windowHolder.GetWindows(_bundleName);
            foreach (var window in _windows) {
                window.Init(OnHide);
            }
        }

        public void DeInit() {
            foreach (var window in _windows) {
                window.DeInit();
            }

            _windowBackground = null;
            _windows = null;
        }

        public void ShowWindow<T>(Action<T> action = null, bool remember = true) where T : BaseWindow {
            foreach (var window in _windows) {
                if ( window is T tWindow ) {
                    if ( _currentWindow != null ) {
                        if ( remember ) {
                            _activeWindows.Push(_currentWindow);
                        }

                        _currentWindow.Hide(false);
                    }

                    _windowBackground.Show();
                    
                    if ( action != null ) {
                        var component = tWindow.GetComponent<T>();
                        if ( component != null ) {
                            action.Invoke(component);
                        }
                    }
                    
                    tWindow.Show();
                    _currentWindow = tWindow;
                    return;
                }
            }
        }

        void Show(BaseWindow window, bool remember = true) {
            if ( _currentWindow != null ) {
                if ( remember ) {
                    _activeWindows.Push(_currentWindow);
                }

                _currentWindow.Hide();
            }

            _windowBackground.Show();
            window.Show();
            _currentWindow = window;
        }
        
        void OnHide(bool tryShowLast = true) {
            _windowBackground.Hide();
            if ( tryShowLast ) {
                TryShowLast();
            }
        }

        void TryShowLast() {
            if ( _activeWindows.Count != 0 ) {
                Show(_activeWindows.Pop(), false);
            } else {
                _currentWindow = null;
            }
        }
    }
}