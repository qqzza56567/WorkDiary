using Prism.Commands;
using System.Windows.Input;
using 工作日報表產生器.Common;

namespace 工作日報表產生器.ViewModel
{
    class ChoiceViewModel : ViewModelBase
    {
        #region ICommand
        public ICommand GoToEmployeeCommand => new DelegateCommand(GoToEmployee);
        public ICommand GoToPageMonthSettingCommand => new DelegateCommand(GoToPageMonthSetting);
        #endregion

        #region Method
        private void GoToEmployee()
        {
            WindowHelper.ShowPageEmployee();
        }

        private void GoToPageMonthSetting()
        {
            WindowHelper.ShowPageMonthSetting();
        }
        #endregion
    }
}
