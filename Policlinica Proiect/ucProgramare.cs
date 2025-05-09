using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class ucProgramare : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        String perspectiva;
        public ucProgramare(String perspectiva)
        {

            InitializeComponent();
            this.perspectiva = perspectiva;
            connection = dbConnection.GetConnection();
            helper.AfiseazaTabela("ServiciiView", dataGridView1, connection);
            ExclusivitateCheckBoxuri(checkBoxNumeC, checkBoxNumeD);
            ExclusivitateCheckBoxuri(checkBoxPrenumeC, checkBoxPrenumeD);

            if (perspectiva != "pacient")
            {
                roundedPanel3.Enabled = false;
                var mapare = new Dictionary<string, Control>
    {
        { "nume", textBoxNume },
        { "prenume", textBoxPrenume },
        { "cnp", textBoxCNP },
        { "telefon", textBoxTelefon },
        { "adresa", textBoxAdresa },
        { "varsta", textBoxVarsta },
        { "asigurat", checkBoxAsigurat }
    };

                try
                {
                    

                    string query = @"
            SELECT p.nume, p.prenume, p.cnp, p.telefon, p.adresa, p.varsta, p.asigurat
            FROM Policlinica.Pacient p
            JOIN Policlinica.ConturiPacient cp ON p.idPacient = cp.idPacient
            JOIN Policlinica.Acces a ON cp.idCont = a.ID
            WHERE a.nume = @username
            LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", perspectiva); // Numele contului conectat

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                foreach (var pair in mapare)
                                {
                                    if (pair.Key == "asigurat")
                                    {
                                        ((CheckBox)pair.Value).Checked = reader.GetBoolean("asigurat");
                                    }
                                    else
                                    {
                                        pair.Value.Text = reader[pair.Key].ToString();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Datele pacientului nu au fost găsite.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la extragerea datelor: " + ex.Message);
                }
               
            }


        }

        private void ExclusivitateCheckBoxuri(CheckBox cb1, CheckBox cb2)
        {
            cb1.CheckedChanged += (s, e) =>
            {
                if (cb1.Checked)
                    cb2.Checked = false;
            };

            cb2.CheckedChanged += (s, e) =>
            {
                if (cb2.Checked)
                    cb1.Checked = false;
            };
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var criterii = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeC, "Denumire" },
        { checkBoxPrenumeC, "Pret" }

    };

            helper.SorteazaDescrescator("Servicii", criterii, connection, dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var criterii = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeC, "Denumire" },
        { checkBoxPrenumeC, "Pret" }

    };

            helper.SorteazaDate("Servicii", criterii, connection, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> conditii = new List<string>();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT * FROM Servicii WHERE 1=1";

                // Preț minim
                if (!string.IsNullOrWhiteSpace(textBoxPretMin.Text))
                {
                    query += " AND pret >= @pretMin";
                    cmd.Parameters.AddWithValue("@pretMin", Convert.ToDecimal(textBoxPretMin.Text));
                }

                // Preț maxim
                if (!string.IsNullOrWhiteSpace(textBoxPretMax.Text))
                {
                    query += " AND pret <= @pretMax";
                    cmd.Parameters.AddWithValue("@pretMax", Convert.ToDecimal(textBoxPretMax.Text));
                }

                // CheckBox Decontat
                if (checkBoxDecontat.Checked)
                {
                    query += " AND decontat = 1";
                }

                cmd.CommandText = query;
                cmd.Connection = connection;

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabel = new DataTable();
                adapter.Fill(tabel);

                dataGridView1.DataSource = tabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la filtrare: " + ex.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string cuvant = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(cuvant))
            {
                helper.CautaInTabela("Servicii", "Denumire", cuvant, connection, dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idPacient = -1;

            if (perspectiva == "pacient")
            {
                // Verificare câmpuri goale
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

                // Validare CNP
                if (!Regex.IsMatch(textBoxCNP.Text, @"^\d{13}$"))
                {
                    MessageBox.Show("CNP-ul trebuie să conțină exact 13 cifre!", "CNP invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validare telefon
                if (!Regex.IsMatch(textBoxTelefon.Text, @"^\d{10}$"))
                {
                    MessageBox.Show("Numărul de telefon trebuie să conțină exact 10 cifre!", "Telefon invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validare vârstă numerică
                if (!int.TryParse(textBoxVarsta.Text, out int v))
                {
                    MessageBox.Show("Vârsta trebuie să fie un număr valid!", "Vârstă invalidă", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construim datele pacientului
                Dictionary<string, object> date = new Dictionary<string, object>
        {
            { "Nume", textBoxNume.Text },
            { "Prenume", textBoxPrenume.Text },
            { "CNP", textBoxCNP.Text },
            { "telefon", textBoxTelefon.Text },
            { "adresa", textBoxAdresa.Text },
            { "varsta", v },
            { "asigurat", checkBoxAsigurat.Checked }
        };

                try
                {
                    helper.AdaugaRand("Pacient", date, connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la adăugarea pacientului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                // Se obține serviciul selectat
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selectează un serviciu din tabel!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string denumireServiciu = dataGridView1.SelectedRows[0].Cells["Denumire"].Value.ToString();

                // Căutare idServiciu
                int idServiciu = -1;
                string queryServiciu = "SELECT idServiciu FROM Servicii WHERE Denumire = @denumire";

                using (MySqlCommand cmd = new MySqlCommand(queryServiciu, connection))
                {
                    cmd.Parameters.AddWithValue("@denumire", denumireServiciu);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        idServiciu = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("Serviciul selectat nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Căutare idPacient după nume și prenume
                string queryPacient = "SELECT idPacient FROM Pacient WHERE Nume = @nume AND Prenume = @prenume ORDER BY idPacient DESC LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(queryPacient, connection))
                {
                    cmd.Parameters.AddWithValue("@nume", textBoxNume.Text);
                    cmd.Parameters.AddWithValue("@prenume", textBoxPrenume.Text);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        idPacient = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("Pacientul nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Obținere dată și oră
                DateTime data = dateTimePicker1.Value.Date;

                if (!TimeSpan.TryParse(textBox1.Text, out TimeSpan ora))
                {
                    MessageBox.Show("Ora introdusă este invalidă (format corect: HH:mm:ss)", "Eroare oră", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Inserare în tabela Programari
                string insertQuery = @"INSERT INTO Programari (idServiciu, idPacient, ora, data)
                        VALUES (@idServiciu, @idPacient, @ora, @data)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idServiciu", idServiciu);
                    cmd.Parameters.AddWithValue("@idPacient", idPacient);
                    cmd.Parameters.AddWithValue("@ora", ora);
                    cmd.Parameters.AddWithValue("@data", data);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Programarea a fost adăugată cu succes!");

                // Întrebare descărcare factură
                DialogResult rezultat = MessageBox.Show("Dorești să descarci factura?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rezultat == DialogResult.Yes)
                {
                    try
                    {
                        // Obținere preț
                        decimal pret = 0;
                        string queryPret = "SELECT Pret FROM Servicii WHERE idServiciu = @idServiciu";
                        using (MySqlCommand cmdPret = new MySqlCommand(queryPret, connection))
                        {
                            cmdPret.Parameters.AddWithValue("@idServiciu", idServiciu);
                            object resultPret = cmdPret.ExecuteScalar();
                            if (resultPret != null && resultPret != DBNull.Value)
                                pret = Convert.ToDecimal(resultPret);
                        }

                        // Generare și deschidere factură
                        string caleFactura = GenereazaFactura(idPacient, textBoxNume.Text, textBoxPrenume.Text, denumireServiciu, data, ora, pret);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = caleFactura,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare la generarea/deschiderea facturii: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenereazaFactura(int idPacient, string nume, string prenume, string denumireServiciu, DateTime data, TimeSpan ora, decimal pret)
        {
            string caleFactura = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Factura_{nume}_{prenume}_{DateTime.Now:yyyyMMddHHmmss}.txt"
            );

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=================================================");
            sb.AppendLine("                Policlinica SANAVITA             ");
            sb.AppendLine("   Strada Grădina Veche NR 90, Galați 800552     ");
            sb.AppendLine("           Telefon: 0747 945 531                 ");
            sb.AppendLine("=================================================\n");

            sb.AppendLine($"Data emiterii: {DateTime.Now}");
            sb.AppendLine($"Factura pentru: {nume} {prenume} (ID: {idPacient})");
            sb.AppendLine($"Serviciu programat: {denumireServiciu}");
            sb.AppendLine($"Data programării: {data:dd.MM.yyyy}");
            sb.AppendLine($"Ora programării: {ora}");
            sb.AppendLine($"Preț: {pret:C}");  // Format valutar

            sb.AppendLine("\n=================================================");
            sb.AppendLine("       Vă mulțumim că ați ales SANAVITA!         ");
            sb.AppendLine("=================================================");

            File.WriteAllText(caleFactura, sb.ToString());

            return caleFactura;
        }


    }
}
