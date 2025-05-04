using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Policlinica_Proiect
{
    public partial class UserControlRapoarte : UserControl
    {
        DatabaseConnection dbConnection = new DatabaseConnection();
        private MySqlConnection connection;
        Comune helper = new Comune();
        public UserControlRapoarte()
        {
            InitializeComponent();
            connection = dbConnection.GetConnection();
            GenereazaGraficProgramariPeAn(connection, chart1);
            GenereazaGraficGrupeDeVarsta(connection, chart2);
        }
        private void GenereazaGraficProgramariPeAn(MySqlConnection connection, Chart chart)
        {
            try
            {
                string query = @"
            SELECT MONTH(data) AS Luna, COUNT(*) AS NrProgramari
            FROM Policlinica.Programari
            WHERE YEAR(data) = YEAR(CURDATE())
            GROUP BY MONTH(data)
            ORDER BY Luna;
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                chart.Series.Clear();
                chart.ChartAreas[0].AxisX.Title = "Luna";
                chart.ChartAreas[0].AxisY.Title = "Număr Programări";

                Series serie = new Series("Programări pe lună");
                serie.ChartType = SeriesChartType.Column;

                while (reader.Read())
                {
                    int luna = reader.GetInt32(0);
                    int nrProgramari = reader.GetInt32(1);
                    string lunaText = new DateTime(1, luna, 1).ToString("MMMM");

                    serie.Points.AddXY(lunaText, nrProgramari);
                }

                chart.Series.Add(serie);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la generarea graficului: " + ex.Message);
            }
        }
        private void GenereazaGraficGrupeDeVarsta(MySqlConnection connection, Chart chart)
        {
            try
            {
                string query = @"
            SELECT 
                CASE 
                    WHEN varsta < 18 THEN 'Minor'
                    WHEN varsta BETWEEN 18 AND 59 THEN 'Tânăr'
                    ELSE 'Bătrân'
                END AS GrupaVarsta,
                COUNT(*) AS NrPacienti
            FROM Policlinica.Pacient
            GROUP BY GrupaVarsta;
        ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                chart.Series.Clear();
                chart.ChartAreas[0].AxisX.Title = "Grupe de vârstă";
                chart.ChartAreas[0].AxisY.Title = "Număr Pacienți";

                Series serie = new Series("Distribuție Pacienți");
                serie.ChartType = SeriesChartType.Pie;

                while (reader.Read())
                {
                    string grupaVarsta = reader.GetString(0);
                    int nrPacienti = reader.GetInt32(1);

                    serie.Points.AddXY(grupaVarsta, nrPacienti);
                }

                chart.Series.Add(serie);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la generarea graficului: " + ex.Message);
            }
        }


    }
}
