using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工作日報表產生器.Model
{
    class Department
    {
        public string Name { get; set; }
        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }
    }
}
