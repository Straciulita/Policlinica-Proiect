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
            helper.PopuleazaComboBoxCuJoin(
    comboBoxCab,
    "personal",
    "cabinet",
    "IdCabinet",
    "IdCabinet",
    "denumire",
    "IdCabinet",
    connection
);
            helper.PopuleazaComboBox(comboBoxFunctie, "personal", "functia", connection);
            helper.PopuleazaComboBox(comboBoxFun, "personal", "functia", connection);
            ExclusivitateCheckBoxuri(checkBoxNumeC, checkBoxNumeD);
            ExclusivitateCheckBoxuri(checkBoxPrenumeC, checkBoxPrenumeD);
            ExclusivitateCheckBoxuri(checkBoxSalariuC, checkBoxSalariuD);
            ExclusivitateCheckBoxuri(checkBoxDataAngjC, checkBoxDataAngjD);
            helper.AfiseazaTabela("Personal", dataGridView1, connection);

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
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            helper.CautaDupaNumePrenume(textBoxSearch.Text, "Personal", dataGridView1, connection);
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
        private void button3_Click(object sender, EventArgs e)
        {
            helper.StergeRandCuDetectareAutomata("Personal", "IdPersonal", dataGridView1, connection);
            helper.AfiseazaTabela("Personal", dataGridView1, connection);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // Validare câmpuri
            if (string.IsNullOrWhiteSpace(textBoxNume.Text))
            {
                MessageBox.Show("Completați câmpul Nume.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPrenume.Text))
            {
                MessageBox.Show("Completați câmpul Prenume.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCNP.Text) || textBoxCNP.Text.Length != 13 || !textBoxCNP.Text.All(char.IsDigit))
            {
                MessageBox.Show("CNP-ul trebuie să conțină exact 13 cifre.");
                return;
            }

            if (comboBoxFun.SelectedValue == null)
            {
                MessageBox.Show("Selectați o funcție.");
                return;
            }

            if (comboBoxCab.SelectedValue == null)
            {
                MessageBox.Show("Selectați un cabinet.");
                return;
            }

            if (!decimal.TryParse(textBoxSalariu.Text, out decimal salariu))
            {
                MessageBox.Show("Salariul trebuie să fie un număr valid.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || !textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Emailul nu este valid (trebuie să conțină caracterul '@').");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTel.Text) || textBoxTel.Text.Length != 10 || !textBoxTel.Text.All(char.IsDigit))
            {
                MessageBox.Show("Telefonul trebuie să conțină exact 10 cifre.");
                return;
            }

            // Dacă toate validările sunt trecute, se adaugă rândul
            Dictionary<string, object> datePersonal = new Dictionary<string, object>
    {
        { "IdPersonal", textBoxId.Text },
        { "Nume", textBoxNume.Text },
        { "Prenume", textBoxPrenume.Text },
        { "CNP", textBoxCNP.Text },
        { "Functia", comboBoxFun.SelectedValue.ToString() },
        { "IdCabinet", comboBoxCab.SelectedValue.ToString() },
        { "Salariu", salariu },
        { "Data_Angajarii", dateTimePickerDataAngj.Value },
        { "Email", textBoxEmail.Text },
        { "Tel", textBoxTel.Text }
    };

            helper.AdaugaRand("Personal", datePersonal, connection);
            helper.AfiseazaTabela("Personal", dataGridView1, connection);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mapare = new Dictionary<string, Control>
    {
        { "IdPersonal", textBoxId },
        { "Nume", textBoxNume },
        { "Prenume", textBoxPrenume },
        { "CNP", textBoxCNP },
        { "Functia", comboBoxFun },
        { "IdCabinet", comboBoxCab },
        { "Salariu", textBoxSalariu },
        { "Data_Angajarii", dateTimePickerDataAngj },
        { "Email", textBoxEmail },
        { "Tel", textBoxTel }

    };
            textBoxId.Enabled = false;
            helper.IncarcaDateInControale(dataGridView1, mapare);
            
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
        { "Nume", textBoxNume },
        { "Prenume", textBoxPrenume },
        { "CNP", textBoxCNP },
        { "Functia", comboBoxFun },
        { "IdCabinet", comboBoxCab },
        { "Salariu", textBoxSalariu },
        { "Data_Angajarii", dateTimePickerDataAngj },
        { "Email", textBoxEmail },
        { "Tel", textBoxTel }
    };

            // Validare câmpuri
            foreach (var camp in campuri)
            {
                if (camp.Value is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
                {
                    MessageBox.Show($"Câmpul '{camp.Key}' trebuie completat.");
                    return;
                }

                if (camp.Value is ComboBox cb && cb.SelectedItem == null)
                {
                    MessageBox.Show($"Selectați o valoare pentru câmpul '{camp.Key}'.");
                    return;
                }
            }

            // Validare specifică
            string cnp = textBoxCNP.Text.Trim();
            if (cnp.Length != 13 || !cnp.All(char.IsDigit))
            {
                MessageBox.Show("CNP-ul trebuie să conțină exact 13 cifre.");
                return;
            }

            string tel = textBoxTel.Text.Trim();
            if (tel.Length != 10 || !tel.All(char.IsDigit))
            {
                MessageBox.Show("Telefonul trebuie să conțină exact 10 cifre.");
                return;
            }

            string email = textBoxEmail.Text.Trim();
            if (!email.Contains("@"))
            {
                MessageBox.Show("Emailul nu este valid (trebuie să conțină caracterul '@').");
                return;
            }

            // Validare salariu numeric
            if (!decimal.TryParse(textBoxSalariu.Text, out _))
            {
                MessageBox.Show("Salariul trebuie să fie un număr valid.");
                return;
            }

            // Dacă toate verificările sunt OK
            helper.UpdateRand("Personal", "IdPersonal", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Personal", dataGridView1, connection);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var criterii = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeC, "Nume" },
        { checkBoxPrenumeC, "Prenume" },
        { checkBoxSalariuC, "Salariu" },
        { checkBoxDataAngjC, "Data_Angajarii" }
    };

            helper.SorteazaDate("Personal", criterii, connection, dataGridView1);

          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var criteriiDesc = new Dictionary<CheckBox, string>
    {
        { checkBoxNumeD, "Nume" },
        { checkBoxPrenumeD, "Prenume" },
        { checkBoxSalariuD, "Salariu" },
        { checkBoxDataAngjD, "Data_Angajarii" }
    };

            helper.SorteazaDescrescator("Personal", criteriiDesc, connection, dataGridView1);
        }
    }
}
