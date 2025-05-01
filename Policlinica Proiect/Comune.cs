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
        public void CautaDupaNumePrenume(string cautare, string numeTabela, DataGridView dgv, MySqlConnection conn)
        {
            try
            {
                string query = $"SELECT * FROM {numeTabela} WHERE Nume LIKE @cautare OR Prenume LIKE @cautare";

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
        public void StergeRandCuDetectareAutomata(string numeTabelaPrincipala,string coloanaId,DataGridView dgv,MySqlConnection conn)
        {
            try
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selectează un rând pentru a fi șters.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object valoareId = dgv.SelectedRows[0].Cells[coloanaId].Value;
                if (valoareId == null || valoareId == DBNull.Value)
                {
                    MessageBox.Show("Nu s-a putut determina ID-ul rândului selectat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obține tabelele care au FK către tabela principală
                string depQuery = @"
            SELECT TABLE_NAME, COLUMN_NAME 
            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
            WHERE REFERENCED_TABLE_NAME = @tabela 
              AND REFERENCED_COLUMN_NAME = @coloana 
              AND CONSTRAINT_SCHEMA = DATABASE()";

                MySqlCommand cmdDep = new MySqlCommand(depQuery, conn);
                cmdDep.Parameters.AddWithValue("@tabela", numeTabelaPrincipala);
                cmdDep.Parameters.AddWithValue("@coloana", coloanaId);

                var dependente = new List<(string tabela, string coloana)>();
                using (MySqlDataReader reader = cmdDep.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dependente.Add((reader.GetString("TABLE_NAME"), reader.GetString("COLUMN_NAME")));
                    }
                }

                // Verifică existența datelor în tabelele dependente
                List<string> tabeleGasite = new List<string>();
                foreach (var (tabela, coloana) in dependente)
                {
                    string countQuery = $"SELECT COUNT(*) FROM {tabela} WHERE {coloana} = @id";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    countCmd.Parameters.AddWithValue("@id", valoareId);
                    int count = Convert.ToInt32(countCmd.ExecuteScalar());

                    if (count > 0)
                        tabeleGasite.Add(tabela);
                }

                // Confirmare dacă sunt înregistrări dependente
                if (tabeleGasite.Count > 0)
                {
                    string msg = $"ID-ul există în: {string.Join(", ", tabeleGasite)}.\nDoriți ștergerea acestor înregistrări și a celui principal?";
                    DialogResult confirm = MessageBox.Show(msg, "Ștergere în cascadă?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm != DialogResult.Yes)
                        return;

                    // Șterge întâi din tabelele dependente
                    foreach (var (tabela, coloana) in dependente)
                    {
                        string delDep = $"DELETE FROM {tabela} WHERE {coloana} = @id";
                        MySqlCommand delDepCmd = new MySqlCommand(delDep, conn);
                        delDepCmd.Parameters.AddWithValue("@id", valoareId);
                        delDepCmd.ExecuteNonQuery();
                    }
                }

                // Șterge rândul principal
                string deleteMain = $"DELETE FROM {numeTabelaPrincipala} WHERE {coloanaId} = @id";
                MySqlCommand deleteCmd = new MySqlCommand(deleteMain, conn);
                deleteCmd.Parameters.AddWithValue("@id", valoareId);
                deleteCmd.ExecuteNonQuery();

                MessageBox.Show("Ștergere realizată cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la ștergere: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void IncarcaDateInControale(DataGridView dgv, Dictionary<string, Control> mapareColoaneControale)
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
                    else if (control is CheckBox) ((CheckBox)control).Checked = false;
                }
                else
                {
                    if (control is TextBox) ((TextBox)control).Text = valoare.ToString();
                    else if (control is ComboBox) ((ComboBox)control).SelectedValue = valoare;
                    else if (control is DateTimePicker && DateTime.TryParse(valoare.ToString(), out DateTime dt))
                        ((DateTimePicker)control).Value = dt;
                    else if (control is CheckBox)
                    {
                        bool rezultat = false;

                        // Interpretare flexibilă a valorii pentru CheckBox
                        if (valoare is bool b)
                            rezultat = b;
                        else if (valoare is int i)
                            rezultat = i != 0;
                        else if (valoare is string s)
                            rezultat = s.ToLower() == "true" || s == "1";

                        ((CheckBox)control).Checked = rezultat;
                    }
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
        public void SorteazaDate(string tabela, Dictionary<CheckBox, string> criteriiSortare, MySqlConnection conn, DataGridView grid)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                List<string> coloaneSortare = new List<string>();

                foreach (var pair in criteriiSortare)
                {
                    if (pair.Key != null && pair.Key.Checked && !string.IsNullOrWhiteSpace(pair.Value))
                    {
                        coloaneSortare.Add($"`{pair.Value}`"); // protejează numele coloanei
                    }
                }

                string query = $"SELECT * FROM `{tabela}`";

                if (coloaneSortare.Count > 0)
                {
                    query += " ORDER BY " + string.Join(", ", coloaneSortare);
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    grid.DataSource = table;
                }
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
