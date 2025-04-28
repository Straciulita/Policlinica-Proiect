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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Creăm o instanță a clasei DatabaseConnection
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Obținem conexiunea la baza de date
            MySql.Data.MySqlClient.MySqlConnection connection = dbConnection.GetConnection();

            if (connection != null)
            {
                // Aici poți adăuga alte operații dacă vrei să lucrezi cu baza de date

                // Închidem conexiunea după ce am terminat
                dbConnection.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Conexiunea la baza de date a eșuat!");
            }
        }

    }
}
