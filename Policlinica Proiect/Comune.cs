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
        public void AfiseazaDetaliiRandSelectat(DataGridView dgv, Label lbl)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow rand = dgv.SelectedRows[0];
                StringBuilder detalii = new StringBuilder();

                foreach (DataGridViewCell cell in rand.Cells)
                {
                    string numeColoana = cell.OwningColumn.HeaderText;
                    string valoare = cell.Value?.ToString() ?? "null";
                    detalii.AppendLine($"{numeColoana}: {valoare}");
                }

                lbl.Text = detalii.ToString();
            }
        }

        public void PopuleazaComboBox(ComboBox combo, string tabela, string coloana, MySqlConnection conn)
        {
            try
            {
                string query = $"SELECT DISTINCT {coloana} FROM `{tabela}`";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Adaugă un rând gol la început
                DataRow emptyRow = table.NewRow();
                emptyRow[coloana] = DBNull.Value; // sau "" dacă preferi string gol
                table.Rows.InsertAt(emptyRow, 0);

                combo.DataSource = table;
                combo.DisplayMember = coloana;
                combo.ValueMember = coloana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la popularea ComboBox-ului: " + ex.Message);
            }
        }

        public void PopuleazaComboBoxCuJoin(
     ComboBox combo,
     string tabela1,
     string tabela2,
     string coloanaJoin1,
     string coloanaJoin2,
     string coloanaAfisata,
     string coloanaValoare,
     MySqlConnection conn)
        {
            try
            {
                string query = $@"
            SELECT DISTINCT 
                t1.{coloanaJoin1} AS ID, 
                CONCAT(t1.{coloanaJoin1}, ' - ', t2.{coloanaAfisata}) AS Nume
            FROM `{tabela1}` t1
            JOIN `{tabela2}` t2 ON t1.{coloanaJoin1} = t2.{coloanaJoin2};";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Adaugă un rând gol la început
                DataRow emptyRow = table.NewRow();
                emptyRow["ID"] = DBNull.Value;
                emptyRow["Nume"] = "";
                table.Rows.InsertAt(emptyRow, 0);

                combo.DataSource = table;
                combo.DisplayMember = "Nume";
                combo.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la popularea ComboBox-ului cu Join: " + ex.Message);
            }
        }



    }
}
