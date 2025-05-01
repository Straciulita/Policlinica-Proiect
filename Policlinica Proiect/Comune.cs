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
        public void StergeRandSelectat(DataGridView dgv, string numeTabela, string numeColoanaID, MySqlConnection conn, Action refreshTabel = null)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează un rând mai întâi.");
                return;
            }

            // Preia rândul selectat
            DataGridViewRow rand = dgv.SelectedRows[0];
            object idValoare = rand.Cells[numeColoanaID]?.Value;

            if (idValoare == null || idValoare == DBNull.Value)
            {
                MessageBox.Show("Nu s-a putut identifica ID-ul rândului.");
                return;
            }

            // Confirmare ștergere
            DialogResult confirmare = MessageBox.Show("Ești sigur că vrei să ștergi acest rând?", "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmare != DialogResult.Yes)
                return;

            // Ștergere din baza de date
            string query = $"DELETE FROM `{numeTabela}` WHERE `{numeColoanaID}` = @id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idValoare);
                int randuriSterse = cmd.ExecuteNonQuery();

                if (randuriSterse > 0)
                {
                    MessageBox.Show("Rândul a fost șters cu succes.");
                    refreshTabel?.Invoke(); // Reîncarcă datele dacă ai pasat o metodă
                }
                else
                {
                    MessageBox.Show("Nu s-a șters niciun rând.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la ștergere: " + ex.Message);
            }
        }

        public void AdaugaRand(string numeTabela, Dictionary<string, object> coloaneSiValori, MySqlConnection conn)
        {
            try
            {
                var coloane = string.Join(", ", coloaneSiValori.Keys);
                var parametri = string.Join(", ", coloaneSiValori.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO `{numeTabela}` ({coloane}) VALUES ({parametri})";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    foreach (var pair in coloaneSiValori)
                    {
                        cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rând adăugat cu succes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la adăugarea rândului: " + ex.Message);
            }
        }

        public void IncarcaDateInControale(DataGridView dgv,Dictionary<string, Control> mapareColoaneControale)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează un rând din tabel.");
                return;
            }

            var rand = dgv.SelectedRows[0];

            foreach (var pair in mapareColoaneControale)
            {
                string numeColoana = pair.Key;
                Control control = pair.Value;

                object valoare = rand.Cells[numeColoana].Value;

                if (valoare == DBNull.Value || valoare == null)
                {
                    if (control is TextBox) ((TextBox)control).Text = "";
                    else if (control is ComboBox) ((ComboBox)control).SelectedIndex = -1;
                    else if (control is DateTimePicker) ((DateTimePicker)control).Value = DateTime.Today;
                }
                else
                {
                    if (control is TextBox) ((TextBox)control).Text = valoare.ToString();
                    else if (control is ComboBox) ((ComboBox)control).SelectedValue = valoare;
                    else if (control is DateTimePicker && DateTime.TryParse(valoare.ToString(), out DateTime dt))
                        ((DateTimePicker)control).Value = dt;
                }
            }
        }
        public void UpdateRand(string tabela,string coloanaCheie,Control controlCheie,Dictionary<string, Control> campuri,MySqlConnection conn)
        {
            try
            {
                List<string> setParts = new List<string>();
                MySqlCommand cmd = new MySqlCommand();
                foreach (var pair in campuri)
                {
                    string coloana = pair.Key;
                    Control control = pair.Value;
                    object valoare = null;

                    if (control is TextBox)
                        valoare = ((TextBox)control).Text;
                    else if (control is ComboBox)
                        valoare = ((ComboBox)control).SelectedValue;
                    else if (control is DateTimePicker)
                        valoare = ((DateTimePicker)control).Value;

                    setParts.Add($"{coloana} = @{coloana}");
                    cmd.Parameters.AddWithValue("@" + coloana, valoare ?? DBNull.Value);
                }

                string valoareCheie = (controlCheie as TextBox)?.Text ?? "";

                if (string.IsNullOrWhiteSpace(valoareCheie))
                {
                    MessageBox.Show("Nu a fost specificat ID-ul pentru actualizare.");
                    return;
                }

                string query = $"UPDATE `{tabela}` SET {string.Join(", ", setParts)} WHERE {coloanaCheie} = @cheie";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cheie", valoareCheie);
                cmd.Connection = conn;

                
                int rezultat = cmd.ExecuteNonQuery();
                

                if (rezultat > 0)
                    MessageBox.Show("Rândul a fost actualizat cu succes.");
                else
                    MessageBox.Show("Actualizarea nu a avut loc (verifică ID-ul).");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Eroare la actualizare: " + ex.Message);
            }
        }
        public void SorteazaDate(string tabela,Dictionary<CheckBox, string> criteriiSortare,MySqlConnection conn,DataGridView grid)
        {
            try
            {
                List<string> coloaneSortare = new List<string>();

                foreach (var pair in criteriiSortare)
                {
                    if (pair.Key.Checked)
                        coloaneSortare.Add(pair.Value);
                }

                string query = $"SELECT * FROM `{tabela}`";

                if (coloaneSortare.Count > 0)
                {
                    query += " ORDER BY " + string.Join(", ", coloaneSortare) + " ASC";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la sortare: " + ex.Message);
            }
        }
        public void SorteazaDescrescator(string tabela,Dictionary<CheckBox, string> criteriiSortare,MySqlConnection conn,DataGridView grid)
        {
            try
            {
                List<string> coloaneSortate = new List<string>();

                foreach (var pair in criteriiSortare)
                {
                    if (pair.Key.Checked)
                        coloaneSortate.Add($"{pair.Value} DESC");
                }

                string query = $"SELECT * FROM `{tabela}`";

                if (coloaneSortate.Count > 0)
                {
                    query += " ORDER BY " + string.Join(", ", coloaneSortate);
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                grid.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la sortare descrescătoare: " + ex.Message);
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
