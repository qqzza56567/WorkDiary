using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using 工作日報表產生器.Common;
using 工作日報表產生器.View;


namespace 工作日報表產生器
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region ChangePage
            WindowHelper.ShowPageChoice = () =>
            {
                FrameMain.Navigate(new PageChoice());
            };

            WindowHelper.ShowPageDepartmentName = () =>
            {
                FrameMain.Navigate(new PageDepartmentName());
            };

            WindowHelper.ShowPageMonthSetting = () =>
            {
                FrameMain.Navigate(new PageMonthSetting());
            };

            WindowHelper.ShowPageEmployee = () =>
            {

            };

            WindowHelper.ShowPageEmployeeList = () =>
            {
                FrameMain.Navigate(new PageEmployeeList());
            };

            WindowHelper.ShowPageCreateDepartmentWorkDiary = () =>
            {
                FrameMain.Navigate(new PageCreateDepartmentWorkDiary());
            };

            WindowHelper.CloseWindow = () =>
            {
                this.Close();
            };
            #endregion

            FrameMain.Navigate(new PageChoice());
        }
    }
}
