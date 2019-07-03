using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工作日報表產生器.Common
{
    class WindowHelper
    {
        /// <summary>
        /// 跳转到主页
        /// </summary>
        public static Action ShowPageChoice;

        /// <summary>
        /// 跳转到員工
        /// </summary>
        public static Action ShowPageEmployee;

        /// <summary>
        /// 跳转到部門名稱
        /// </summary>
        public static Action ShowPageDepartmentName;

        /// <summary>
        /// 跳转到員工列表
        /// </summary>
        public static Action ShowPageEmployeeList;

        /// <summary>
        /// 跳转到時間設定
        /// </summary>
        public static Action ShowPageMonthSetting;

        /// <summary>
        /// 跳转到部門日報表產生
        /// </summary>
        public static Action ShowPageCreateDepartmentWorkDiary;

        /// <summary>
        /// 關閉主視窗
        /// </summary>
        public static Action CloseWindow;
    }
}
