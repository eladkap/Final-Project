using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Entity;

namespace FinalLab
{
    public class QueryBuilder
    {
        private DatabaseConnector _connector;

        public QueryBuilder()
        {
            _connector = new DatabaseConnector();
        }
        /*
        private void PerformQuery2(string queryString)
        {
            DatabaseContext

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(queryString, _connector.Connection);
            _connector.ConnectToDatabase();
            //
            _connector.DisconnectFromDatabase();
        }
        */
        private void PerformQuery(string queryString) // TODO: use LINQ
        {
            
        }

        public void AddChainDetailsByObject(Chain chain)
        {
           // DbContext context=new DbContext
        }
        /*
        public Item GetItemByCode(string itemCode)
        {
            try
            {

                _connector.ConnectToDatabase();

                PerformQuery("select database.items");
                _connector.DisconnectFromDatabase();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        */
    }
}
