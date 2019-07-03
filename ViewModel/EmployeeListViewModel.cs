using System.Linq;
using Prism.Commands;
using System.Windows.Input;
using 工作日報表產生器.Common;
using 工作日報表產生器.Model;
using System.Collections.ObjectModel;

namespace 工作日報表產生器.ViewModel
{
    class EmployeeListViewModel : ViewModelBase
    {
        #region Property
        private ObservableCollection<Employee> _dataGridEmployees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> DataGridEmployees
        {
            get { return _dataGridEmployees; }
            set
            {
                _dataGridEmployees = value;
                OnPropertyChanged();
            }
        }

        private string _textboxEmployeeName;
        public string TextboxEmployeeName
        {
            get { return _textboxEmployeeName; }
            set
            {
                _textboxEmployeeName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public EmployeeListViewModel()
        {
            _dataGridEmployees = WorkDiarySetting.Department.Employees;
        }

        #region ICommand
        public ICommand AddEmployeeCommand => new DelegateCommand(AddEmployee);
        public ICommand RemoveEmployeeCommand => new DelegateCommand<string>(RemoveEmployee);
        public ICommand GoToPreviousPageCommand => new DelegateCommand(GoToPreviousPage);
        public ICommand GoToNextPageCommand => new DelegateCommand(GoToNextPage);
        #endregion

        #region Method
        private void AddEmployee()
        {
            _dataGridEmployees.Add(new Employee(_textboxEmployeeName));
            TextboxEmployeeName = "";
        }

        private void RemoveEmployee(string name)
        {
            foreach (Employee employee in _dataGridEmployees.ToArray())
            {
                if (employee.IsSelected == true)
                {
                    _dataGridEmployees.Remove(employee);
                }
            }
        }

        private void GoToPreviousPage()
        {
            WindowHelper.ShowPageDepartmentName();
        }

        private void GoToNextPage()
        {
            SaveEmployeeList();
            WindowHelper.ShowPageCreateDepartmentWorkDiary();
        }

        private void SaveEmployeeList()
        {
            WorkDiarySetting.Department.Employees = _dataGridEmployees;
        }
        #endregion
    }
}
