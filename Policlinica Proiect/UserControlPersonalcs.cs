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
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            helper.AfiseazaTabela("Personal", dataGridView1, connection);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            helper.CautaPersonal(textBoxSearch.Text.Trim(), dataGridView1, connection);
        }
    }
}
