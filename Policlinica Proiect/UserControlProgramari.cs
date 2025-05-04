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
    public partial class UserControlProgramari : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlProgramari()
        {

            InitializeComponent();
            connection = dbConnection.GetConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper.AfiseazaTabela("Programari", dataGridView1, connection);
            helper.AfiseazaTabela("Consultatie", dataGridView2, connection);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView2, labelDetalii);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            helper.AfiseazaDetaliiRandSelectat(dataGridView1, labelDetalii);
        }

        private void button3_Click(object sender, EventArgs e)
        {   if(dataGridView1.SelectedRows.Count > 0 || dataGridView2.SelectedRows.Count > 0)
            {
                // Verificăm dacă există rânduri selectate în oricare dintre cele două DataGridView-uri
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    helper.StergeRandCuDetectareAutomata("Programari", "IdProgramare", dataGridView1, connection);
                    helper.AfiseazaTabela("Programari", dataGridView1, connection);
                }
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    helper.StergeRandCuDetectareAutomata("Consultatie", "IdConsultatie", dataGridView2, connection);
                    helper.AfiseazaTabela("Consultatie", dataGridView2, connection);
                }
            }
            else
            {
                MessageBox.Show("Selectează un rând dintr-unul dintre tabele pentru a-l șterge!", "Nicio selecție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var mapare = new Dictionary<string, Control>
    {
        { "IdServiciu", textBoxIdServ },
        { "IdProgramare", textBoxIdPr },
        { "IdPacient", textBoxIdPacient },
        { "Ora", textBoxOra },
        { "data", dateTimePickerData },
        


    };
               
                helper.IncarcaDateInControale(dataGridView1, mapare);
                helper.AfiseazaTabela("Programari", dataGridView1, connection);

            }
             if (dataGridView2.SelectedRows.Count > 0)
            {
                var mapare = new Dictionary<string, Control>
    {
        { "IdConsultatie", textBoxId },
        { "IdProgramare", textBoxIdProg },
        { "Diagnostic", textBoxDiagnostic },
        { "Tratament", textBoxTratament },



    };

                helper.IncarcaDateInControale(dataGridView2, mapare);
                helper.AfiseazaTabela("Consultatie", dataGridView2, connection);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
        { "IdProgramare", textBoxIdPr },
        { "IdServiciu", textBoxIdServ },
        { "IdPacient", textBoxIdPacient },
        { "Ora", textBoxOra },
        { "data", dateTimePickerData },

    };

            helper.UpdateRand("Programari", "IdProgramare", textBoxIdPr, campuri, connection);
            helper.AfiseazaTabela("Programari", dataGridView1, connection);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var campuri = new Dictionary<string, Control>
    {
        { "IdConsultatie", textBoxId },
        { "IdProgramare", textBoxIdProg },
        { "Diagnostic", textBoxDiagnostic },
        { "Tratament", textBoxTratament },

    };

            helper.UpdateRand("Consultatie", "IdConsultatie", textBoxId, campuri, connection);
            helper.AfiseazaTabela("Consultatie", dataGridView2, connection);
        
    }
    }
}
