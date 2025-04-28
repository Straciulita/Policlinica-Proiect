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
        String perspectiva;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificăm dacă ambele câmpuri sunt completate
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Te rog completează toate câmpurile!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Oprim execuția dacă lipsesc date
            }

            // Creăm o instanță a clasei DatabaseConnection
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Obținem conexiunea la baza de date
            MySql.Data.MySqlClient.MySqlConnection connection = dbConnection.GetConnection();

            if (connection != null)
            {
                try
                {
                    string username = textBoxUsername.Text;
                    string parola = passwordTextBox.Text;

                    string query = "SELECT * FROM Acces WHERE nume = @nume AND parola = @parola";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nume", username);
                    cmd.Parameters.AddWithValue("@parola", parola);

                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //MessageBox.Show("Acces permis!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Aici poți deschide alt form dacă vrei
                        perspectiva = username;
                        Form2 form2 = new Form2(perspectiva);
                        this.Hide(); // Ascunde form1
                        form2.Show();

                    }
                    else
                    {
                        MessageBox.Show("Username sau parolă greșită!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la conectare: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection(connection);
                }
            }
            else
            {
                MessageBox.Show("Conexiunea la baza de date a eșuat!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perspectiva = "pacient";
            Form2 form2 = new Form2(perspectiva);
            this.Hide(); // Ascunde form1
            form2.Show();
        }
    }
}
