using Prism.Commands;
using 工作日報表產生器.Common;
using 工作日報表產生器.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Windows;

namespace 工作日報表產生器.ViewModel
{
    class CreateDepartmentWorkDiaryViewModel : ViewModelBase
    {
        #region Property
        private string _textBoxYear;
        public string TextBlockYear
        {
            get { return _textBoxYear; }
        }

        private string _textBlockMonth;
        public string TextBlockMonth
        {
            get { return _textBlockMonth; }
        }

        private string _textBlockDepartmentName;
        public string TextBlockDepartmentName
        {
            get { return _textBlockDepartmentName; }
        }

        private ObservableCollection<Employee> _dataGridEmployeeList;
        public ObservableCollection<Employee> DataGridEmployeeList
        {
            get { return _dataGridEmployeeList; }
        }

        private Visibility _progressBar;
        public Visibility ProgressBar
        {
            get { return _progressBar; }
            set
            {
                _progressBar = value;
                OnPropertyChanged();
            }
        }
        #endregion 

        public CreateDepartmentWorkDiaryViewModel()
        {
            _textBoxYear = WorkDiarySetting.MonthlyCalendar.Year;
            _textBlockMonth = WorkDiarySetting.MonthlyCalendar.Month;
            _textBlockDepartmentName = WorkDiarySetting.Department.Name;
            _dataGridEmployeeList = WorkDiarySetting.Department.Employees;
        }

        #region ICommand
        public ICommand GoToPreviousPageCommand => new DelegateCommand(GoToPreviousPage);
        public ICommand GenerateWorkDiaryCommand => new DelegateCommand(GenerateWorkDiary);
        #endregion

        #region Method
        private void GoToPreviousPage()
        {
            WindowHelper.ShowPageEmployeeList();
        }

        private void GenerateWorkDiary()
        {
            _progressBar = Visibility.Visible;
            WorkDiaryGenerator workDiaryGenerator = new WorkDiaryGenerator(WorkDiarySetting.MonthlyCalendar, WorkDiarySetting.Department);
            workDiaryGenerator.Generate();
            WorkDiarySetting.Save();
            _progressBar = Visibility.Collapsed;
        }
        #endregion
    }
}
