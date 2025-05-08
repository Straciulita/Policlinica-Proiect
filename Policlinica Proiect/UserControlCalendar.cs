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
    public partial class UserControlCalendar : UserControl
    {
        public static int _year, _month;
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlCalendar()
        {
            InitializeComponent();
            _month = DateTime.Now.Month;
            _year = DateTime.Now.Year;
            connection = dbConnection.GetConnection(); 
            showDay(_month, _year);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("S-a dat click pe sagetica stg");
            _month -= 1;
            if (_month < 1)
            {
                _month = 12;
                _year -= 1;
            }
            showDay(_month, _year);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("S-a dat click pe sagetica dr");
            _month += 1;
            if (_month > 12)
            {
                _month = 1;
                _year += 1;
            }
            showDay(_month, _year);
        }
        private void AfiseazaProgramari(object sender, string data)
        {
            lbProg.Text = ""; // Resetăm conținutul afișat anterior

            try
            {
                if (dbConnection != null)
                {
                   

                    string query = "SELECT Nume, Prenume, Ora, Serviciu FROM vw_prog_detalii WHERE Data = @data ORDER BY Ora";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@data", data);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        string nume = reader["Nume"].ToString();
                        string prenume = reader["Prenume"].ToString();
                        string ora = reader["Ora"].ToString();
                        string serviciu = reader["Serviciu"].ToString();

                        sb.AppendLine($"{ora} - {nume} {prenume} ({serviciu})");
                    }

                    lbProg.Text = sb.Length > 0 ? sb.ToString() : "Nicio programare pentru această zi.";

                    reader.Close();
                    
                }
                else
                {
                    lbProg.Text = "Eroare conexiune.";
                }
            }
            catch (Exception ex)
            {
                lbProg.Text = "Eroare: " + ex.Message;
            }
        }



        private List<int> GetZileCuProgramari(int luna, int an)
        {
            List<int> zile = new List<int>();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open(); // doar dacă nu e deja deschisă

                string query = "SELECT DISTINCT DAY(data) AS zi FROM vw_prog_detalii WHERE MONTH(data) = @luna AND YEAR(data) = @an";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@luna", luna);
                cmd.Parameters.AddWithValue("@an", an);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        zile.Add(reader.GetInt32("zi"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la verificarea programărilor: " + ex.Message);
            }

            return zile;
        }


        private void showDay(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            _year = year;
            _month = month;

            string monthName = new System.Globalization.DateTimeFormatInfo().GetMonthName(month);
            lbMounth.Text = monthName.ToUpper() + " " + year;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));

            // Preluăm toate zilele care au programări
            List<int> zileCuProgramari = GetZileCuProgramari(month, year);

            // spațiere pentru începutul lunii
            for (int i = 1; i <= startDayOfWeek; i++)
            {
                ucDayrs blankDay = new ucDayrs("");
                flowLayoutPanel1.Controls.Add(blankDay);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                bool areProgramari = zileCuProgramari.Contains(i);
                ucDayrs uc = new ucDayrs(i.ToString(), areProgramari);
                uc.ZiSelectata += AfiseazaProgramari;
                flowLayoutPanel1.Controls.Add(uc);
            }
        }


    }
}
