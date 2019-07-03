using System;
using System.Drawing;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using 工作日報表產生器.Model;

namespace 工作日報表產生器.Common
{
    class WorkDiaryGenerator
    {
        #region Property
        private MonthlyCalendar _monthlyCalendar;
        private Department _department;
        private Excel.Application _excelApp;
        private Excel.Workbook _excelWB;
        private Excel.Worksheet _excelWS;
        private bool _isSunday;
        #endregion

        public WorkDiaryGenerator(MonthlyCalendar monthlyCalendar, Department department)
        {
            _monthlyCalendar = monthlyCalendar;
            _department = department;
        }

        #region Method
        public void Generate()
        {
            BuildExcel();
            AddWorksheet_WorkDiary(_monthlyCalendar.DaysInMonth);
            SaveExcel();
            CloseExcel();
        }

        private void BuildExcel()
        {
            _excelApp = new Excel.Application();

            if (_excelApp == null)
            {
                MessageBox.Show("請安裝office!!");
            }
            _excelApp.Visible = false;//不顯示excel程式
            _excelWB = _excelApp.Workbooks.Add();
        }

        private void AddWorksheet_WorkDiary(int daysInMonth)
        {
            for (int day = 1; day <= daysInMonth; day++)
            {
                _isSunday = false;
                _excelWS = _excelWB.Worksheets.Add();

                #region 標籤設定
                _excelWS.Name = day.ToString();
                string strWeek = _monthlyCalendar.GetDayOfWeek(day);
                if (strWeek == "星期六")
                {
                    _excelWS.Tab.Color = Color.OrangeRed;
                }
                if (strWeek == "星期天")
                {
                    _isSunday = true;
                    _excelWS.Tab.Color = Color.Red;
                }
                #endregion

                #region 設定標頭格線
                Excel.Range range_Title = _excelWS.Range["A1", "K2"];
                range_Title.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                #endregion

                #region 設定第一行標頭
                Excel.Range range_TitleRow1 = range_Title.Range["A1", "K1"];
                range_TitleRow1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range_TitleRow1.Font.Color = Color.White;
                range_TitleRow1.Interior.Color = Color.Gray;
                range_TitleRow1.RowHeight = 30;
                range_TitleRow1.Range["B1", "C1"].Merge();
                range_TitleRow1.Range["B1", "C1"].Item[1] = _department.Name + "-工作日報表(彙整)";
                range_TitleRow1.Range["G1", "I1"].Merge();
                range_TitleRow1.Range["G1", "I1"].Item[1] = _monthlyCalendar.GetDate(day);
                range_TitleRow1.Range["J1", "K1"].Merge();
                range_TitleRow1.Range["J1", "K1"].Item[1] = strWeek;
                #endregion

                #region 設定第二行標頭
                Excel.Range range_TitleRow2 = range_Title.Range["A2", "K2"];
                range_TitleRow2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range_TitleRow2.Font.Name = "Microsoft JhengHei UI";
                range_TitleRow2.Font.Size = 10;
                range_TitleRow2.Font.Bold = true;
                range_TitleRow2.WrapText = true;
                range_TitleRow2.EntireColumn.AutoFit();
                range_TitleRow2.Font.Color = Color.Black;
                range_TitleRow2.Interior.Color = Color.LightGray;
                range_TitleRow2.Range["A1"].Item[1] = "職員";
                range_TitleRow2.Range["B1"].Item[1] = "專案、工地名稱";
                range_TitleRow2.Range["C1", "E1"].Merge();
                range_TitleRow2.Range["C1", "E1"].Item[1] = "今日工作內容詳述";
                range_TitleRow2.Range["F1"].Item[1] = "出勤時數";
                range_TitleRow2.Range["G1", "H1"].Merge();
                range_TitleRow2.Range["G1", "H1"].Item[1] = "加班時數";
                range_TitleRow2.Range["I1"].Item[1] = "報價收費";
                range_TitleRow2.Range["J1", "K1"].Merge();
                range_TitleRow2.Range["J1", "K1"].Item[1] = "備註";
                #endregion

                #region 設定欄位寬度
                _excelWS.Range["A1"].ColumnWidth = 12;
                _excelWS.Range["B1"].ColumnWidth = 20;
                _excelWS.Range["C1"].ColumnWidth = 15;
                _excelWS.Range["D1"].ColumnWidth = 15;
                _excelWS.Range["E1"].ColumnWidth = 15;
                _excelWS.Range["F1"].ColumnWidth = 8;
                _excelWS.Range["G1"].ColumnWidth = 4;
                _excelWS.Range["H1"].ColumnWidth = 4;
                _excelWS.Range["I1"].ColumnWidth = 12;
                _excelWS.Range["J1"].ColumnWidth = 10;
                _excelWS.Range["K1"].ColumnWidth = 10;
                #endregion

                for (int i = 0; i < _department.Employees.Count; i++)
                {
                    int startRow = (6 * i) + 3;
                    int endRow = (6 * i) + 7;

                    Excel.Range range_WorkRecord = _excelWS.Range["A" + startRow.ToString(), "K" + endRow.ToString()];
                    range_WorkRecord.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range_WorkRecord.Font.Size = 10;
                    range_WorkRecord.RowHeight = 30;

                    Excel.Range range_EmployeeName = _excelWS.Range["A" + (startRow).ToString(), "A" + (startRow + 2).ToString()];
                    range_EmployeeName.Interior.Color = Color.FromArgb(0, 196, 189, 151);
                    range_EmployeeName.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range_EmployeeName.Font.Size = 12;
                    range_EmployeeName.Font.Bold = true;
                    range_EmployeeName.Merge();
                    range_EmployeeName.Item[1] = _department.Employees[i].Name;

                    Excel.Range range_TotalTime = _excelWS.Range["A" + (startRow + 3).ToString(), "A" + (startRow + 4).ToString()];
                    range_TotalTime.Interior.Color = Color.FromArgb(0, 217, 217, 217);
                    range_TotalTime.Font.Size = 12;
                    range_TotalTime.Font.Bold = true;
                    range_TotalTime.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range_TotalTime.Item[2].Font.Color = Color.Red;
                    range_TotalTime.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                    range_TotalTime.Item[1] = "工時合計";
                    range_TotalTime.Item[2] = "=SUM(F" + startRow + " : G" + endRow + ")";

                    for (int j = 0; j < 5; j++)
                    {
                        Excel.Range range_WorkDescription = _excelWS.Range["C" + (startRow + j).ToString(), "E" + (startRow + j).ToString()];
                        range_WorkDescription.Merge();

                        Excel.Range range_OverHour = _excelWS.Range["G" + (startRow + j).ToString(), "H" + (startRow + j).ToString()];
                        range_OverHour.Merge();

                        Excel.Range range_Remark = _excelWS.Range["J" + (startRow + j).ToString(), "K" + (startRow + j).ToString()];
                        range_Remark.Merge();
                    }

                    if (_isSunday)
                    {
                        Excel.Range range_WorkDescription = _excelWS.Range["C" + (startRow).ToString(), "E" + (startRow).ToString()];
                        range_WorkDescription.Font.Color = Color.Red;
                        range_WorkDescription.Item[1] = "例假日";
                    }

                    range_WorkRecord.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

                    Excel.Range range_Group = _excelWS.Range["A" + (startRow + 1), "A" + (endRow)];
                    range_Group.Rows.Group();

                    Excel.Range range_Space = _excelWS.Range["A" + (endRow + 1).ToString(), "K" + (endRow + 1).ToString()];
                    range_Space.Merge();
                }
            }
        }

        private void SaveExcel()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + _department.Name + " - 工作日報表";
            _excelWB.SaveAs(filePath);
            MessageBox.Show(filePath);
        }

        private void CloseExcel()
        {
            _excelWB.Close();
            _excelApp.Workbooks.Close();
            _excelApp.Quit();

            _excelWS = null;
            _excelWB = null;
            _excelApp = null;

            
            //刪除 Windows工作管理員中的Excel.exe 進程，  
 //           System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelApp);
   //         System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelWB);
     //       System.Runtime.InteropServices.Marshal.ReleaseComObject(_excelWS);

            //呼叫垃圾回收  
            GC.Collect();
        }
        #endregion
    }
}
