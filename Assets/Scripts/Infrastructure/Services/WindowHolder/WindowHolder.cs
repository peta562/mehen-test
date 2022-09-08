using System.Collections.Generic;
using Infrastructure.Services.UIFactory;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.Services.WindowHolder {
    public sealed class WindowHolder : IWindowHolder {
        readonly Dictionary<string, List<BaseWindow>> _windows = new Dictionary<string, List<BaseWindow>>();
        readonly IUIFactory _uiFactory;
        
        Transform _windowsRoot;
        WindowBackground _windowBackground;

        public WindowHolder(IUIFactory uiFactory) {
            _uiFactory = uiFactory;
        }

        public void CreateWindowsRoot() {
            _windowsRoot = _uiFactory.CreateWindowsRoot();
        }

        public WindowBackground GetWindowBackground() {
            if ( _windowBackground ) {
                return _windowBackground;
            }

            _windowBackground = _uiFactory.CreateWindowBackground(_windowsRoot);

            return _windowBackground;
        }

        public List<BaseWindow> GetWindows(string bundleName) {
            if ( _windows.TryGetValue(bundleName, out var windows) ) {
                return windows;
            }
            
            var createdWindows = CreateWindows(bundleName);
            _windows.Add(bundleName, createdWindows);

            return _windows[bundleName];
        }

        List<BaseWindow> CreateWindows(string bundleName) {
            var windows = _uiFactory.CreateWindows(bundleName, _windowsRoot);

            foreach (var window in windows) {
                window.gameObject.SetActive(false);
            }

            return windows;
        }
    }
}