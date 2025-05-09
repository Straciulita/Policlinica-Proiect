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
    public partial class UserControlServicii : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlServicii()
        {
            InitializeComponent();
            
            connection = dbConnection.GetConnection();
            helper.AfiseazaTabela("servicii", dataGridView1, connection);
            ExclusivitateCheckBoxuri(checkBoxNumeC, checkBoxNumeD);
            ExclusivitateCheckBoxuri(checkBoxPrenumeC, checkBoxPrenumeD);
            helper.PopuleazaComboBoxCuJoin(
    comboBoxPersonal,
    "personal",
    "personal",
    "IdPersonal",
    "IdPersonal",
    "nume",
    "IdPersonal",
    connection
);
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
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            helper.StergeRandCuDetectareAutomata("Servicii", "IdServiciu", dataGridView1, connection);
            helper.AfiseazaTabela("servicii", dataGridView1, connection);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string cuvant = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(cuvant))
            {
                helper.CautaInTabela("Servicii", "Denumire", cuvant, connection, dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mapare = new Dictionary<string, Control>
    {
        { "IdServiciu", textBoxId },
        { "Denumire", textBoxNume },
        { "Descriere", textBoxPrenume },
        { "pret", textBoxCNP },
        { "idPersonal", comboBoxPersonal },
        { "decontat", checkBoxAsigurat }


    };
            textBoxId.Enabled = false;
            helper.IncarcaDateInControale(dataGridView1, mapare);
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

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifică dacă câmpurile esențiale sunt completate
            if (string.IsNullOrWhiteSpace(textBoxNume.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrenume.Text) ||
                string.IsNullOrWhiteSpace(textBoxCNP.Text) ||
                comboBoxPersonal.SelectedValue == null)
            {
                MessageBox.Show("Te rugăm să completezi toate câmpurile necesare!", "Câmpuri incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificare dacă pretul este un număr valid
            if (!decimal.TryParse(textBoxCNP.Text, out decimal pret) || pret < 0)
            {
                MessageBox.Show("Prețul trebuie să fie un număr valid și pozitiv!", "Preț invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Adăugare dacă totul e valid
            Dictionary<string, object> datePersonal = new Dictionary<string, object>
    {
        { "Denumire", textBoxNume.Text },
        { "Descriere", textBoxPrenume.Text },
        { "Pret", pret },
        { "IdPersonal", comboBoxPersonal.SelectedValue.ToString() },
        { "decontat", checkBoxAsigurat.Checked }
    };

            try
            {
                helper.AdaugaRand("Servicii", datePersonal, connection);
                helper.AfiseazaTabela("Servicii", dataGridView1, connection);
                MessageBox.Show("Serviciul a fost adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la adăugare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {

      { "IdServiciu", textBoxId },
        { "Denumire", textBoxNume },
        { "Descriere", textBoxPrenume },
        { "pret", textBoxCNP },
        { "idPersonal", comboBoxPersonal },
        { "decontat", checkBoxAsigurat }
    };

            helper.UpdateRand("Servicii", "IdServiciu", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Servicii", dataGridView1, connection);
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

        private void button8_Click(object sender, EventArgs e)
        {
            var criterii = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeC, "Denumire" },
        { checkBoxPrenumeC, "Pret" }

    };

            helper.SorteazaDescrescator("Servicii", criterii, connection, dataGridView1);
        }
    }
}
