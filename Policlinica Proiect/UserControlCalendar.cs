using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class UserControlCalendar : UserControl
    {
        public static int _year, _mounth;
        public UserControlCalendar()
        {
            InitializeComponent();
            showDay(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void showDay(int mounth, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _mounth = mounth;

            string monthName = new System.Globalization.DateTimeFormatInfo().GetMonthName(mounth);
            lbMounth.Text = monthName.ToUpper()+ " "+ year;
            DateTime startofTheMounth = new DateTime(year, mounth, 1);
            int day = DateTime.DaysInMonth(year, mounth);
            int week = Convert.ToInt32(startofTheMounth.DayOfWeek.ToString("d"));
            for (int i = 1; i <= week; i++)
            {
                ucDayrs uc = new ucDayrs("");
                flowLayoutPanel1.Controls.Add(uc);

            }
            for(int i = 1; i <=day; i++)
            {
                ucDayrs uc = new ucDayrs(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }



        }
    }
}
