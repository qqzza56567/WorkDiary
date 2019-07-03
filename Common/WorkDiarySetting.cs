using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using 工作日報表產生器.Model;

namespace 工作日報表產生器.Common
{
    class WorkDiarySetting
    {
        public static string SettingPath;
        public static MonthlyCalendar MonthlyCalendar;
        public static Department Department = new Department();

        public static void Save()
        {
            StreamWriter writer = new StreamWriter(SettingPath + @"\setting.txt");
            writer.WriteLine(MonthlyCalendar.Year);
            writer.WriteLine(MonthlyCalendar.Month);
            writer.WriteLine(Department.Name);
            foreach (Employee employee in Department.Employees)
            {
                writer.WriteLine(employee.Name);
            }
            writer.Close();
        }

        public static void Load()
        {
            string year;
            string month;
            StreamReader reader = new StreamReader(SettingPath + @"\setting.txt");
            year = reader.ReadLine();
            month = reader.ReadLine();
            MonthlyCalendar = new MonthlyCalendar(year, month);
            Department.Name = reader.ReadLine();
            foreach(string name in reader.ReadToEnd().Split())
            {
                if (string.IsNullOrEmpty(name)) { }
                else
                    Department.Employees.Add(new Employee(name));
            }   
        }
    }
}
