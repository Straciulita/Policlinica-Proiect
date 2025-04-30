using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    internal class Comune
    {


        public void AfiseazaTabela(string numeTabela, DataGridView dgv, MySqlConnection conn)
        {
            try
            {
                string query = $"SELECT * FROM `{numeTabela}`";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgv.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la interogare: " + ex.Message);
            }
        }
        public void CautaPersonal(string cautare, DataGridView dgv, MySqlConnection conn)
        {
            try
            {
                string query = "SELECT * FROM Personal WHERE Nume LIKE @cautare OR Prenume LIKE @cautare";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cautare", "%" + cautare + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Nu s-a găsit niciun rezultat pentru căutarea introdusă.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgv.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la căutare: " + ex.Message);
            }
        }
    }
}
