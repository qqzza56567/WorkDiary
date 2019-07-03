using System;
using Prism.Commands;
using System.Windows.Input;
using 工作日報表產生器.Common;

namespace 工作日報表產生器.ViewModel
{
    class MonthSettingViewModel : ViewModelBase
    {
        #region property
        private string _textboxYear;
        public string TextboxYear
        {
            get { return _textboxYear; }
            set
            {
                _textboxYear = value;
                OnPropertyChanged();
            }
        }

        private string _textboxMonth;
        public string TextboxMonth
        {
            get { return _textboxMonth; }
            set
            {
                if (string.IsNullOrEmpty(value)) { value = DateTime.Now.Month.ToString(); }
                _textboxMonth = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MonthSettingViewModel()
        {
            _textboxYear = DateTime.Now.Year.ToString();
            _textboxMonth = DateTime.Now.Month.ToString();
        }

        #region ICommand 
        public ICommand GoToPreviousPageCommand => new DelegateCommand(GoToPreviousPage);
        public ICommand GoToNextPageCommand => new DelegateCommand(GoToNextPage);
        #endregion

        #region Method
        private void GoToPreviousPage()
        {
            WindowHelper.ShowPageChoice();
        }

        private void GoToNextPage()
        {
            SaveSetting();
            WindowHelper.ShowPageDepartmentName();
        }

        private void SaveSetting()
        {
            WorkDiarySetting.MonthlyCalendar = new MonthlyCalendar(_textboxYear, _textboxMonth);
        }
        #endregion
    }
}
