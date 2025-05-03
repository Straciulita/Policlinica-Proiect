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
            // Verificare câmpuri goale
            if (string.IsNullOrWhiteSpace(textBoxNume.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrenume.Text) ||
                string.IsNullOrWhiteSpace(textBoxCNP.Text) ||
                string.IsNullOrWhiteSpace(textBoxTel.Text) ||
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
            if (!Regex.IsMatch(textBoxTel.Text, @"^\d{10}$"))
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

            // Dacă toate validările sunt trecute, se adaugă rândul
            Dictionary<string, object> date = new Dictionary<string, object>
    {
        { "Nume", textBoxNume.Text },
        { "Prenume", textBoxPrenume.Text },
        { "CNP", textBoxCNP.Text },
        { "telefon", textBoxTel.Text },
        { "adresa", textBoxAdresa.Text },
        { "varsta", v },
        { "asigurat", checkBoxAsigurat.Checked }
    };

            try
            {
                helper.AdaugaRand("Pacient", date, connection);
                helper.AfiseazaTabela("Pacient", dataGridView1, connection);
                MessageBox.Show("Pacientul a fost adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelDetalii_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxVarstaMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVarstaMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrenume_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCNP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVarsta_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxVarstaD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPrenumeD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxNumeD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxVarstaC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPrenumeC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxNumeC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
