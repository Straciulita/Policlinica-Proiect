using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class Form2 : Form
    {
        String perspectiva;
        public Form2(string perspectiva)
        {
            InitializeComponent();
            this.perspectiva = perspectiva;
            this.label1.Text = perspectiva;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // la fiecare secundă
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo culturaRomana = new CultureInfo("ro-RO");
            string dataFormata = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", culturaRomana);
            labelOraData.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dataFormata); // capitalizează prima literă
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
