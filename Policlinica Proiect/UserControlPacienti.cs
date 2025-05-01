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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Policlinica_Proiect
{
    public partial class UserControlPacienti : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlPacienti()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            ExclusivitateCheckBoxuri(checkBoxNumeC, checkBoxNumeD);
            ExclusivitateCheckBoxuri(checkBoxPrenumeC, checkBoxPrenumeD);
            ExclusivitateCheckBoxuri(checkBoxVarstaC, checkBoxVarstaD);
            
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
            helper.AfiseazaTabela("Pacient", dataGridView1, connection);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            helper.CautaDupaNumePrenume(textBoxSearch.Text, "Pacient", dataGridView1, connection);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            helper.StergeRandCuDetectareAutomata("Pacient", "IdPacient", dataGridView1, connection);
            helper.AfiseazaTabela("Pacient", dataGridView1, connection);
        }

        private void checkBoxAsigurat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mapare = new Dictionary<string, Control>
    {
        { "IdPacient", textBoxId },
        { "Nume", textBoxNume },
        { "Prenume", textBoxPrenume },
        { "CNP", textBoxCNP },
        { "telefon", textBoxTel },
        { "adresa", textBoxAdresa },
        { "varsta", textBoxVarsta },
        { "asigurat", checkBoxAsigurat }


    };
            textBoxId.Enabled = false;
            helper.IncarcaDateInControale(dataGridView1, mapare);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Pacient WHERE 1=1"; // pornim cu o condiție universal adevărată
                List<MySqlParameter> parametri = new List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(textBoxVarstaMin.Text))
                {
                    query += " AND Varsta >= @min";
                    parametri.Add(new MySqlParameter("@min", int.Parse(textBoxVarstaMin.Text)));
                }

                if (!string.IsNullOrWhiteSpace(textBoxVarstaMax.Text))
                {
                    query += " AND Varsta <= @max";
                    parametri.Add(new MySqlParameter("@max", int.Parse(textBoxVarstaMax.Text)));
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);
                foreach (var p in parametri)
                    cmd.Parameters.Add(p);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la filtrare: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Dacă toate validările sunt trecute, se adaugă rândul
            Dictionary<string, object> date = new Dictionary<string, object>
    {

        { "Nume", textBoxNume.Text },
        { "Prenume", textBoxPrenume.Text },
        { "CNP", textBoxCNP.Text },
        { "telefon", textBoxTel.Text },
        { "adresa", textBoxAdresa.Text },
        { "varsta", int.TryParse(textBoxVarsta.Text, out int v) ? v : (object)DBNull.Value },
        { "asigurat", checkBoxAsigurat.Checked }
    };

            helper.AdaugaRand("Pacient", date, connection);
            helper.AfiseazaTabela("Pacient", dataGridView1, connection);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
       
        { "Nume", textBoxNume },
        { "Prenume", textBoxPrenume },
        { "CNP", textBoxCNP },
        { "telefon", textBoxTel },
        { "adresa", textBoxAdresa },
        { "varsta", textBoxVarsta },
        { "asigurat", checkBoxAsigurat }
    };

            helper.UpdateRand("Pacient", "IdPacient", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Pacient", dataGridView1, connection);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var criterii = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeC, "Nume" },
        { checkBoxPrenumeC, "Prenume" },
        { checkBoxVarstaC, "Varsta" }
       
    };

            helper.SorteazaDate("Pacient", criterii, connection, dataGridView1);

        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            var criteriiDesc = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeD, "Nume" },
        { checkBoxPrenumeD, "Prenume" },
        { checkBoxVarstaD, "Varsta" }
    };

            helper.SorteazaDescrescator("Pacient", criteriiDesc, connection, dataGridView1);
        }
    }
}
