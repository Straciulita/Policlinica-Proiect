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

        private void panel1_Click(object sender, EventArgs e)

        {
            Debug.WriteLine("S-a dat click pe ucDayrs!");

            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                this.BackColor = Color.FromArgb(255, 159, 79);
                
            }
            else
            {
                checkBox1.Checked = false;
                this.BackColor = Color.White;
            }
        }

        public ucDayrs(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();
        }

        private void ucDayrs_Load(object sender, EventArgs e)
        {

        }
    }
}
