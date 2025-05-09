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
    public partial class UserControlCabinete : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlCabinete()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            helper.AfiseazaTabela("Cabinet", dataGridView1, connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string cuvant = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(cuvant))
            {
                helper.CautaInTabela("Cabinet", "Denumire", cuvant, connection, dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label20.Enabled = false;
            textBoxId.Enabled = false;
            var mapare = new Dictionary<string, Control>
    {
        { "IdCabinet", textBoxId },
        { "Denumire", textBoxNume },
        


    };
            
            helper.IncarcaDateInControale(dataGridView1, mapare);
        

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {

     { "IdCabinet", textBoxId },
        { "Denumire", textBoxNume },
    };

            helper.UpdateRand("Cabinet", "IdCabinet", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Cabinet", dataGridView1, connection);
            label20.Enabled = true;
            textBoxId.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            helper.StergeRandCuDetectareAutomata("Cabinet", "IdCabinet", dataGridView1, connection);
            helper.AfiseazaTabela("Cabinet", dataGridView1, connection);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verificări preliminare
            if (string.IsNullOrWhiteSpace(textBoxId.Text) || string.IsNullOrWhiteSpace(textBoxNume.Text))
            {
                MessageBox.Show("Te rugăm să completezi toate câmpurile!", "Câmpuri incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validare pentru ID (trebuie să fie număr întreg)
            if (!int.TryParse(textBoxId.Text, out int idCabinet))
            {
                MessageBox.Show("ID-ul trebuie să fie un număr întreg valid!", "ID invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, object> datePersonal = new Dictionary<string, object>
    {
        { "IdCabinet", idCabinet },
        { "Denumire", textBoxNume.Text }
    };

            // Inserare și reîncărcare tabelă
            helper.AdaugaRand("Cabinet", datePersonal, connection);
            helper.AfiseazaTabela("Cabinet", dataGridView1, connection);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }
    }
}
