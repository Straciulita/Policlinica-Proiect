using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Policlinica_Proiect
{
    public partial class Form2 : Form
    {
        String perspectiva;
        int clickCount = 0;
        DatabaseConnection dbConnection = new DatabaseConnection();

        private MySqlConnection connection;

        public Form2(string perspectiva)
        {
            InitializeComponent();
            this.perspectiva = perspectiva;
            panel4.Visible = false;
            this.label1.Text = perspectiva;
            // inițializez conexiunea și o stochez în câmpul de clasă
            connection = dbConnection.GetConnection();
        }

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



        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // la fiecare secundă
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo culturaRomana = new CultureInfo("ro-RO");
            string dataFormata = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", culturaRomana);
            labelOraData.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dataFormata); // capitalizează prima literă
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPersonal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            admin.Controls.Clear(); 
            UserControlPersonalcs pv = new UserControlPersonalcs();
            pv.Dock = DockStyle.Fill;
            admin.Controls.Add(pv);
        }

        private void buttonPacienti_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonProgram_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void buttonMeniu_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount % 2 == 1)
            {
                panel4.Visible = true;


            }
            else
            {
                panel4.Visible = false;
            }
        }

        

        
    }
}
