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
    public partial class UserControlProgramcs : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlProgramcs()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            helper.AfiseazaTabela("Program", dataGridView1, connection);
            helper.AfiseazaTabela("Orar", dataGridView2, connection);
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
            helper.PopuleazaComboBoxCuJoin(
    comboBoxProg,
    "program",
    "program",
    "Idprogram",
    "Idprogram",
    "zi",
    "Idprogram",
    connection
);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper.AfiseazaTabela("Program", dataGridView1, connection);
            helper.AfiseazaTabela("Orar", dataGridView2, connection);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView2, labelDetalii);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView2.SelectedRows.Count > 0)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    helper.StergeRandCuDetectareAutomata("Program", "IdProgram", dataGridView1, connection);
                    helper.AfiseazaTabela("Program", dataGridView1, connection);
                }
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    helper.StergeRandCuDetectareAutomata("Orar", "IdOrar", dataGridView2, connection);
                    helper.AfiseazaTabela("Orar", dataGridView2, connection);
                }
            }
            else
            {
                MessageBox.Show("Selectează un rând dintr-unul dintre tabele pentru a-l șterge!", "Nicio selecție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView2.SelectedRows.Count > 0)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var mapare = new Dictionary<string, Control>
    {
        { "IdProgram", textBoxId },
        { "Zi", textBoxZi },
        { "OraInceput", textBoxOraSt },
        { "OraSfarsit", textBoxOraSf },
        


    };
                    textBoxId.Enabled = false;
                    helper.IncarcaDateInControale(dataGridView1, mapare);
                }
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    var mapare = new Dictionary<string, Control>
    {
        { "IdOrar", textBoxIdOrar },
        { "idPersonal", comboBoxPersonal },
        { "IdProgram",  comboBoxProg }


    };
                    textBoxIdOrar.Enabled = false;
                    helper.IncarcaDateInControale(dataGridView2, mapare);
                }
            }
            else
            {
                MessageBox.Show("Selectează un rând dintr-unul dintre tabele pentru a-l modifica!", "Nicio selecție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
        { "IdProgram", textBoxId },
        { "Zi", textBoxZi },
        { "OraInceput", textBoxOraSt },
        { "OraSfarsit", textBoxOraSf },

    };
            textBoxId.Enabled = true;
            helper.UpdateRand("Program", "IdProgram", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Program", dataGridView1, connection);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
       { "IdOrar", textBoxIdOrar },
        { "idPersonal", comboBoxPersonal },
        { "IdProgram",  comboBoxProg }

    };
            
            helper.UpdateRand("Orar", "IdOrar", textBoxIdOrar, campuri, connection);
            helper.AfiseazaTabela("Orar", dataGridView2, connection);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verificare completare câmpuri
            if (string.IsNullOrWhiteSpace(textBoxId.Text) ||
                string.IsNullOrWhiteSpace(textBoxZi.Text) ||
                string.IsNullOrWhiteSpace(textBoxOraSt.Text) ||
                string.IsNullOrWhiteSpace(textBoxOraSf.Text))
            {
                MessageBox.Show("Te rugăm să completezi toate câmpurile!", "Câmpuri incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validare IdProgram ca int
            if (!int.TryParse(textBoxId.Text, out int idProgram))
            {
                MessageBox.Show("ID-ul trebuie să fie un număr întreg valid!", "ID invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construirea dicționarului după validări
            Dictionary<string, object> datePersonal = new Dictionary<string, object>
    {
        { "IdProgram", idProgram },
        { "Zi", textBoxZi.Text },
        { "OraInceput", textBoxOraSt.Text },
        { "OraSfarsit", textBoxOraSf.Text },
    };

            helper.AdaugaRand("Program", datePersonal, connection);
            helper.AfiseazaTabela("Program", dataGridView1, connection);
        }

        private void button9_Click(object sender, EventArgs e)
        {
           

           

            // Verificare dacă a fost selectat un personal
            if (comboBoxPersonal.SelectedValue == null)
            {
                MessageBox.Show("Selectați un personal din listă!", "Personal lipsă", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificare dacă a fost selectat un program
            if (comboBoxProg.SelectedValue == null)
            {
                MessageBox.Show("Selectați un program din listă!", "Program lipsă", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dacă toate sunt valide, construim dicționarul
            Dictionary<string, object> dateOrar = new Dictionary<string, object>
    {
        
        { "idPersonal", comboBoxPersonal.SelectedValue.ToString() },
        { "IdProgram", comboBoxProg.SelectedValue.ToString() }
    };

            helper.AdaugaRand("Orar", dateOrar, connection);
            helper.AfiseazaTabela("Orar", dataGridView2, connection);
        }

    }
}
