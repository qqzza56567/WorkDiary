using Prism.Commands;
using System.Windows.Input;
using 工作日報表產生器.Common;

namespace 工作日報表產生器.ViewModel
{
    class DepartmentNameViewModel : ViewModelBase
    {
        #region Property
        private string _textboxDepartmentName;
        public string TextboxDepartmentName
        {
            get { return _textboxDepartmentName; }
            set
            {
                _textboxDepartmentName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public DepartmentNameViewModel()
        {
            _textboxDepartmentName = WorkDiarySetting.Department.Name;
        }

        #region ICommand
        public ICommand GoToPreviousPageCommand => new DelegateCommand(GoToPreviousPage);
        public ICommand GoToNextPageCommand => new DelegateCommand(GoToNextPage);
        #endregion

        #region Method
        private void GoToPreviousPage()
        {
            WindowHelper.ShowPageMonthSetting();
        }

        private void GoToNextPage()
        {
            SaveDepartmentName();
            WindowHelper.ShowPageEmployeeList();
        }

        private void SaveDepartmentName()
        {
            WorkDiarySetting.Department.Name = _textboxDepartmentName;
        }
        #endregion
    }
}
