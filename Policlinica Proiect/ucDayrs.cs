using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class ucDayrs : UserControl
    {
        string _day, date, weekday;
        public event EventHandler<string> ZiSelectata;

        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();

        public ucDayrs(string day, bool areProgramari = false)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            date = UserControlCalendar._month + "/" + _day + "/" + UserControlCalendar._year;

            if (string.IsNullOrEmpty(_day))
            {
                this.Enabled = false;
            }

            checkBox1.Checked = areProgramari;
            checkBox1.Visible = areProgramari;

            if (areProgramari)
            {
                panel1.BackColor = Color.FromArgb(200, 217, 250); // Fundal pentru zilele cu programare
            }
        }

        private void Dumi()
        {
            try
            {
                DateTime day = DateTime.Parse(date);
                weekday = day.ToString("ddd");

                if (weekday == "Sun")
                {
                    label1.ForeColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }
            catch (Exception) { }
        }

        private void ucDayrs_Load(object sender, EventArgs e)
        {
            Dumi();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("S-a dat click pe ucDayrs!" + _day);

            //checkBox1.Checked = !checkBox1.Checked;
            panel1.BackColor = checkBox1.Checked
                ? Color.FromArgb(200, 217, 250)
                : Color.White;

            if (!string.IsNullOrEmpty(date))
            {
                ZiSelectata?.Invoke(this, DateTime.Parse(date).ToString("yyyy-MM-dd"));
            }
        }
    }
}
