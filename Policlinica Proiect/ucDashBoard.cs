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
    public partial class ucDashBoard : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
       
        public ucDashBoard()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            try
            {


                string query = @"SELECT * FROM Policlinica.vw_prog_detalii 
                         WHERE DATE(Data) = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Asumând că ai un DataGridView numit dataGridView1 pe controlul tău
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la afișare: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                string query = @"SELECT * FROM Policlinica.vw_prog_detalii 
                         WHERE DATE(Data) = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Asumând că ai un DataGridView numit dataGridView1 pe controlul tău
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la afișare: " + ex.Message);
            }
           
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            helper.CautaDupaNumePrenume(textBoxSearch.Text, "vw_prog_detalii", dataGridView1, connection);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dataGridView1.Rows[e.RowIndex];

                    string nume = row.Cells["Nume"].Value?.ToString() ?? "";
                    string prenume = row.Cells["Prenume"].Value?.ToString() ?? "";
                    string ora = row.Cells["Ora"].Value?.ToString() ?? "";
                    string data = Convert.ToDateTime(row.Cells["Data"].Value).ToString("yyyy-MM-dd");
                    string serviciu = row.Cells["Serviciu"]?.Value?.ToString() ?? "Necunoscut";

                    string query = @"
                SELECT p.varsta, c.diagnostic
                FROM Policlinica.Programari pr
                JOIN Policlinica.Pacient p ON pr.idPacient = p.idPacient
                LEFT JOIN Policlinica.Consultatie c ON pr.idProgramare = c.idProgramare
                WHERE p.nume = @nume AND p.prenume = @prenume AND pr.data = @data AND pr.ora = @ora";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nume", nume);
                        cmd.Parameters.AddWithValue("@prenume", prenume);
                        cmd.Parameters.AddWithValue("@data", data);
                        cmd.Parameters.AddWithValue("@ora", ora);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int varsta = -1;
                            List<string> diagnostice = new List<string>();

                            while (reader.Read())
                            {
                                if (varsta == -1)
                                    varsta = Convert.ToInt32(reader["varsta"]);

                                string diagnostic = reader["diagnostic"] != DBNull.Value
                                    ? reader["diagnostic"].ToString()
                                    : "Fără diagnostic";

                                if (!diagnostice.Contains(diagnostic))
                                    diagnostice.Add(diagnostic);
                            }

                            if (varsta != -1)
                            {
                                string diagText = string.Join("\n- ", diagnostice);
                                labelDetalii.Text = $"Nume: {nume} {prenume}\nVârstă: {varsta}\nServiciu: {serviciu}\nDiagnostice:\n- {diagText}";
                            }
                            else
                            {
                                labelDetalii.Text = "Informații indisponibile.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message);
                }
            }
        }


        int idProgramareSelectat = -1;

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    string nume = dataGridView1.CurrentRow.Cells["Nume"].Value?.ToString() ?? "";
                    string prenume = dataGridView1.CurrentRow.Cells["Prenume"].Value?.ToString() ?? "";

                    lbNumePrenume.Text = $"{nume} {prenume}";
                    panelConsultatie.Enabled = true;

                    // Căutăm programarea pentru pacientul cu numele și prenumele dat, în funcție de data curentă
                    string query = @"
                SELECT pr.idProgramare
                FROM Policlinica.Pacient p
                JOIN Policlinica.Programari pr ON pr.idPacient = p.idPacient
                WHERE p.nume = @nume AND p.prenume = @prenume AND pr.data = CURDATE()
                LIMIT 1;
            ";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@prenume", prenume);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        idProgramareSelectat = Convert.ToInt32(result);
                        
                        // Poți folosi acum idProgramareSelectat pentru salvarea consultației
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a găsit o programare pentru astăzi pentru acest pacient.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selectează un pacient din listă mai întâi.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panelConsultatie.Enabled = false;
            lbNumePrenume.Text = "";
            Dictionary<string, object> date = new Dictionary<string, object>
    {   { "IdProgramare", idProgramareSelectat },
        { "Diagnostic", textBoxDiagnostic.Text },
        { "Tratament", textBoxTratament.Text }

    };


            helper.AdaugaRand("Consultatie", date, connection);
            textBoxDiagnostic.Text = "";
            textBoxTratament.Text = "";
    }


           

        private void textBoxDiagnostic_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTratament_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
