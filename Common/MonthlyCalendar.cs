using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工作日報表產生器.Common
{
    class MonthlyCalendar
    {
        #region Property
        private int _year;
        public string Year { get { return _year.ToString(); } }

        private int _month;
        public string Month { get { return _month.ToString(); } }

        public int DaysInMonth { get { return DateTime.DaysInMonth(_year, _month); } }
        #endregion

        public MonthlyCalendar(string year, string month)
        {
            _year = int.Parse(year);
            _month = int.Parse(month);
        }

        #region Method
        public string GetDayOfWeek(int day)
        {
            string yearStr = String.Format("{0:0000}", _year);
            string monthStr = String.Format("{0:00}", _month);
            string dayStr = String.Format("{0:00}", day);
            string dateStr = yearStr + monthStr + dayStr;
            DateTime date = DateTime.ParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "星期天";

                case DayOfWeek.Monday:
                    return "星期一";

                case DayOfWeek.Tuesday:
                    return "星期二";

                case DayOfWeek.Wednesday:
                    return "星期三";

                case DayOfWeek.Thursday:
                    return "星期四";

                case DayOfWeek.Friday:
                    return "星期五";

                case DayOfWeek.Saturday:
                    return "星期六";

                default:
                    return "星期七";
            }
        }

        public string GetDate(int day)
        {
            string yearStr = String.Format("{0:0000}", _year);
            string monthStr = String.Format("{0:00}", _month);
            string dayStr = String.Format("{0:00}", day);

            return yearStr + "/" + monthStr + "/" + dayStr;
        }
        #endregion
    }
}
