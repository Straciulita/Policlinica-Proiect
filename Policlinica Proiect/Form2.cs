using MySql.Data.MySqlClient;
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
        int clickCount = 0;
        DatabaseConnection dbConnection = new DatabaseConnection();

        private MySqlConnection connection;

        public Form2(string perspectiva)
        {
            InitializeComponent();
            this.perspectiva = perspectiva;
            panel4.Visible = false;
            this.label1.Text = perspectiva;
            // inițializez conexiunea și o stochez în câmpul de clasă
            connection = dbConnection.GetConnection();
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

        private void buttonPersonal_Click(object sender, EventArgs e)
        {
            
            main.Controls.Clear(); 
            panel4.Visible = false; // ascunde panelul 4
            UserControlPersonalcs pv = new UserControlPersonalcs();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void buttonPacienti_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonProgram_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonMeniu_Click(object sender, EventArgs e)
        {
           if(panel4.Visible == false)
            {
                panel4.Visible = true; // arată panelul 4
            }
            else
            {
                panel4.Visible = false; // ascunde panelul 4
            }
        }

        

        
    }
}
