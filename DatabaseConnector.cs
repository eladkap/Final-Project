using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinalLab
{
    public class DatabaseConnector
    {
        private MySqlConnection _connection;
        public void ConnectToDatabase()
        {
            try
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=root";
                _connection = new MySqlConnection(connectionString);
                _connection.Open(); // OpenAsync
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public void DisconnectFromDatabase()
        {
            _connection?.Close();
        }

        public MySqlConnection Connection { get { return _connection; } }
    }
}
