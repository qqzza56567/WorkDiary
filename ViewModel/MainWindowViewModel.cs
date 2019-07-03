using Prism.Commands;
using System;
using System.Windows.Input;
using 工作日報表產生器.Common;

namespace 工作日報表產生器.ViewModel
{
    class MainWindowViewModel
    {
        public ICommand CloseWindowCommand => new DelegateCommand(CloseWindow);

        public MainWindowViewModel()
        {
            WorkDiarySetting.SettingPath = AppDomain.CurrentDomain.BaseDirectory;
            WorkDiarySetting.Load();
        }

        private void CloseWindow()
        {
            WindowHelper.CloseWindow();
        }
    }
}
