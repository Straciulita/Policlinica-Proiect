using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class Form1 : Form
    {
        String perspectiva;
        // Creăm o instanță a clasei DatabaseConnection
        DatabaseConnection dbConnection = new DatabaseConnection();
        Comune helper = new Comune();
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

            dbConnection.CloseConnection(connection);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perspectiva = "pacient";
            Form2 form2 = new Form2(perspectiva);
            this.Hide(); // Ascunde form1
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNume.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrenume.Text) ||
                string.IsNullOrWhiteSpace(textBoxCNP.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefon.Text) ||
                string.IsNullOrWhiteSpace(textBoxAdresa.Text) ||
                string.IsNullOrWhiteSpace(textBoxVarsta.Text))
            {
                MessageBox.Show("Te rugăm să completezi toate câmpurile!", "Câmpuri incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(textBoxCNP.Text, @"^\d{13}$"))
            {
                MessageBox.Show("CNP-ul trebuie să conțină exact 13 cifre!", "CNP invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(textBoxTelefon.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Numărul de telefon trebuie să conțină exact 10 cifre!", "Telefon invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxVarsta.Text, out int varsta))
            {
                MessageBox.Show("Vârsta trebuie să fie un număr valid!", "Vârstă invalidă", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idCont == -1)
            {
                MessageBox.Show("Contul nu a fost creat corect! Te rugăm să reiei procesul.", "Eroare cont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection conn = dbConnection.GetConnection();

            if (conn != null)
            {
                try
                {
                    // Adaugă pacientul
                    int idPacient;
                    using (MySqlCommand cmdPacient = new MySqlCommand(
                        "INSERT INTO Pacient (Nume, Prenume, CNP, telefon, adresa, varsta, asigurat) " +
                        "VALUES (@nume, @prenume, @cnp, @telefon, @adresa, @varsta, @asigurat); SELECT LAST_INSERT_ID();", conn))
                    {
                        cmdPacient.Parameters.AddWithValue("@nume", textBoxNume.Text);
                        cmdPacient.Parameters.AddWithValue("@prenume", textBoxPrenume.Text);
                        cmdPacient.Parameters.AddWithValue("@cnp", textBoxCNP.Text);
                        cmdPacient.Parameters.AddWithValue("@telefon", textBoxTelefon.Text);
                        cmdPacient.Parameters.AddWithValue("@adresa", textBoxAdresa.Text);
                        cmdPacient.Parameters.AddWithValue("@varsta", varsta);
                        cmdPacient.Parameters.AddWithValue("@asigurat", checkBoxAsigurat.Checked);

                        idPacient = Convert.ToInt32(cmdPacient.ExecuteScalar());
                    }

                    // Legătură între pacient și cont
                    using (MySqlCommand cmdLink = new MySqlCommand(
                        "INSERT INTO ConturiPacient (idPacient, idCont) VALUES (@idPacient, @idCont)", conn))
                    {
                        cmdLink.Parameters.AddWithValue("@idPacient", idPacient);
                        cmdLink.Parameters.AddWithValue("@idCont", idCont);
                        cmdLink.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pacient adăugat cu succes și legat la cont!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    roundedPanel3.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adăugare pacient: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
            else
            {
                MessageBox.Show("Conexiunea la baza de date a eșuat!");
            }
        }


        private int idCont = -1; // Variabilă membră globală, ca să poți accesa idCont și în button3_Click
        private void button4_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string parola = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(parola))
            {
                MessageBox.Show("Te rugăm să completezi toate câmpurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conn = dbConnection.GetConnection();

            if (conn != null)
            {
                try
                {
                    string checkQuery = "SELECT COUNT(*) FROM Acces WHERE nume = @nume";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nume", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Acest nume de utilizator este deja folosit!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Inserare cont în tabelul Acces
                    using (MySqlCommand insertCmd = new MySqlCommand(
                        "INSERT INTO Acces (nume, parola) VALUES (@nume, @parola); SELECT LAST_INSERT_ID();", conn))
                    {
                        insertCmd.Parameters.AddWithValue("@nume", username);
                        insertCmd.Parameters.AddWithValue("@parola", parola);
                        idCont = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    // Afișează panel-ul pentru completarea datelor pacientului
                    roundedPanel3.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la creare cont: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
            else
            {
                MessageBox.Show("Conexiunea la baza de date a eșuat!");
            }
        }

    }
}
