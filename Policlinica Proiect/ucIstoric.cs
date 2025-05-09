using MySql.Data.MySqlClient;
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
    public partial class ucIstoric : UserControl
    {
        String perspectiva;
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public ucIstoric(String perspectiva)
        {
            InitializeComponent();
            this.perspectiva = perspectiva;
            connection = dbConnection.GetConnection();
            IncarcaIstoric(); // ✅ încarcă datele automat la inițializare
        }
        private void IncarcaIstoric()
        {
            try
            {
                

                string query = @"
            SELECT pr.data, pr.ora, c.diagnostic, c.tratament
            FROM Policlinica.ConturiPacient cp
            JOIN Policlinica.Acces a ON cp.idCont = a.ID
            JOIN Policlinica.Pacient p ON cp.idPacient = p.idPacient
            JOIN Policlinica.Programari pr ON pr.idPacient = p.idPacient
            LEFT JOIN Policlinica.Consultatie c ON c.idProgramare = pr.idProgramare
            WHERE a.nume = @utilizator";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@utilizator", perspectiva);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataTable trecut = dt.Clone();
                DataTable viitor = dt.Clone();
                StringBuilder diagnostice = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    DateTime data = Convert.ToDateTime(row["data"]);
                    TimeSpan ora = TimeSpan.Parse(row["ora"].ToString());

                    if (data.Date < DateTime.Now.Date)
                    {
                        trecut.Rows.Add(row.ItemArray);
                    }
                    else
                    {
                        viitor.Rows.Add(row.ItemArray);
                    }

                    if (row["diagnostic"] != DBNull.Value || row["tratament"] != DBNull.Value)
                    {
                        string diag = row["diagnostic"] != DBNull.Value ? row["diagnostic"].ToString() : "(fără diagnostic)";
                        string trat = row["tratament"] != DBNull.Value ? row["tratament"].ToString() : "(fără tratament)";
                        diagnostice.AppendLine($"Diagnostic: {diag}\nTratament: {trat}\n---");
                    }
                }

                dataGridView1.DataSource = trecut;
                dataGridView2.DataSource = viitor;
                label4.Text = diagnostice.Length > 0 ? diagnostice.ToString() : "Niciun diagnostic sau tratament disponibil.";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea istoricului: " + ex.Message);
            }
          
        }


        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
