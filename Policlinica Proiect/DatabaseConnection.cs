using MySql.Data.MySqlClient;
using System;

namespace Policlinica_Proiect
{
    public class DatabaseConnection
    {
        // String-ul de conexiune la baza de date
        private string connectionString = "Server=localhost;Database=policlinica;User ID=root;Password=oracle;";

        // Metoda care stabilește conexiunea la baza de date
        public MySqlConnection GetConnection()
        {
            try
            {
                // Creăm o conexiune folosind string-ul de conexiune
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open(); // Deschidem conexiunea

                Console.WriteLine("Conexiune la baza de date reușită!");
                return connection; // Returnăm obiectul MySqlConnection
            }
            catch (Exception ex)
            {
                // Afișăm mesajul de eroare în caz de eșec
                Console.WriteLine("Eroare la conectarea la baza de date: " + ex.Message);
                return null; // Returnăm null dacă nu s-a putut stabili conexiunea
            }
        }

        // Metodă pentru a închide conexiunea
        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close(); // Închidem conexiunea
                Console.WriteLine("Conexiunea a fost închisă.");
            }
        }
    }
}
