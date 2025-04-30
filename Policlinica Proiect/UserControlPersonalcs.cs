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
    public partial class UserControlPersonalcs : UserControl

    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlPersonalcs()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            helper.PopuleazaComboBoxCuJoin(
    comboBoxCabinet,
    "personal",
    "cabinet",
    "IdCabinet",
    "IdCabinet",
    "denumire",
    "IdCabinet",
    connection
);
            helper.PopuleazaComboBox(comboBoxFunctie, "personal", "functia", connection);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            helper.AfiseazaTabela("Personal", dataGridView1, connection);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            helper.CautaPersonal(textBoxSearch.Text.Trim(), dataGridView1, connection);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> conditii = new List<string>();

            // Filtrare după funcție
            if (comboBoxFunctie.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(comboBoxFunctie.SelectedValue.ToString()))
            {
                string functie = comboBoxFunctie.SelectedValue.ToString();
                conditii.Add($"Functia = '{functie}'");
            }

            // Filtrare după cabinet
            if (comboBoxCabinet.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(comboBoxCabinet.SelectedValue.ToString()))
            {
                string idCabinet = comboBoxCabinet.SelectedValue.ToString();
                conditii.Add($"IdCabinet = '{idCabinet}'");
            }

            // Salariu minim
            if (!string.IsNullOrWhiteSpace(textBoxSalMin.Text))
            {
                if (decimal.TryParse(textBoxSalMin.Text, out decimal salMin))
                    conditii.Add($"Salariu >= {salMin}");
                else
                {
                    MessageBox.Show("Salariul minim introdus nu este valid.");
                    return;
                }
            }

            // Salariu maxim
            if (!string.IsNullOrWhiteSpace(textBoxSalMax.Text))
            {
                if (decimal.TryParse(textBoxSalMax.Text, out decimal salMax))
                    conditii.Add($"Salariu <= {salMax}");
                else
                {
                    MessageBox.Show("Salariul maxim introdus nu este valid.");
                    return;
                }
            }

            // Filtrare după data angajării
            bool filtrareData = false;
            if (dateTimeAngjStart.Value.Date == DateTime.Today && dateTimePickerAngjFin.Value.Date == DateTime.Today)
            {
                DialogResult rezultat = MessageBox.Show("Doriți să filtrați după data de azi?", "Filtrare după dată", MessageBoxButtons.YesNo);
                filtrareData = rezultat == DialogResult.Yes;
            }
            else
            {
                filtrareData = true;
            }

            if (filtrareData)
            {
                string startDate = dateTimeAngjStart.Value.ToString("yyyy-MM-dd");
                string endDate = dateTimePickerAngjFin.Value.ToString("yyyy-MM-dd");
                conditii.Add($"data_angajarii BETWEEN '{startDate}' AND '{endDate}'");
            }

            // Construire interogare SQL
            string query = "SELECT * FROM Personal";
            if (conditii.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditii);
            }

            // Executare interogare
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
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


    }
}
