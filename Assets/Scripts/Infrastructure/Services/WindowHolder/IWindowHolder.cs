using System.Collections.Generic;
using UI.Windows;

namespace Infrastructure.Services.WindowHolder {
    public interface IWindowHolder : IService {
        public WindowBackground GetWindowBackground();
        public List<BaseWindow> GetWindows(string bundleName);
        void CreateWindowsRoot();
    }
}