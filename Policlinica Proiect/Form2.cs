﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            this.label1.Text = perspectiva;
            if (perspectiva == "pacient")
            {
                button6.Visible = false;
            }
            if (perspectiva != "pacient")
            {
                label14.Visible = false;
            }

            meniuAdmin.Visible = false;
            meniuDoctor.Visible = false;
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
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlPersonalcs pv = new UserControlPersonalcs();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void buttonPacienti_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlPacienti pv = new UserControlPacienti();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);


        }

        private void buttonProgram_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlProgramcs pv = new UserControlProgramcs();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }


        private void buttonMeniu_Click(object sender, EventArgs e)
        {
            if(perspectiva=="admin")
            meniuAdmin.Visible = !meniuAdmin.Visible; // comutare vizibilitate
           
            else if (perspectiva == "doctor")
            {
                meniuDoctor.Visible = !meniuDoctor.Visible;
            }
            else
            {
                MeniuPacient.Visible = !MeniuPacient.Visible;
            }

        }

        private void buttonServicii_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlServicii pv = new UserControlServicii();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void buttonProgramari_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlProgramari pv = new UserControlProgramari();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlCabinete pv = new UserControlCabinete();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void buttonRapoarte_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlRapoarte pv = new UserControlRapoarte();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void buttonCalendar_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            UserControlCalendar pv = new UserControlCalendar();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Închide Form2
            this.Close();

            // Creează o instanță a Form1 și o deschide
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void buttonPacientiDoc_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            ucDashBoard pv = new ucDashBoard();
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label14, "Pentru a accesa istoricul trebuie sa iti faci cont!");
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            ucProgramare pv = new ucProgramare(perspectiva);
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control c in main.Controls)
                c.Visible = false;

            ucIstoric pv = new ucIstoric(perspectiva);
            pv.Dock = DockStyle.Fill;
            main.Controls.Add(pv);
        }
    }
}
