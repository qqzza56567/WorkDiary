using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工作日報表產生器.Model
{
    class Employee
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public Employee(string name)
        {
            Name = name;
            IsSelected = false;
        }
    }
}
