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

        public MySqlConnection Connection { get { return _connector.Connection; } }

        private void PerformQuery(MySqlCommand sqlCmd)
        {
            _connector.ConnectToDatabase();
            using (MySqlTransaction transaction = Connection.BeginTransaction())
            {
                try
                {
                    sqlCmd.Connection = _connector.Connection;
                    sqlCmd.ExecuteNonQuery(); // async
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    throw;
                }
                finally
                {
                    _connector.DisconnectFromDatabase();
                }
            }
        }

        public void InsertItem(Item item, Chain chain)
        {
            try
            {
                string queryString = "INSERT INTO `database`.items (item_type,item_code,chain_id) VALUES (@itemType,@itemCode,@chainId)";
                MySqlCommand sqlCmd = new MySqlCommand(queryString, Connection);
                sqlCmd.Parameters.AddWithValue("@itemType", item.ItemType);
                sqlCmd.Parameters.AddWithValue("@itemCode", item.ItemCode);
                sqlCmd.Parameters.AddWithValue("@chainId", chain.ChainId);
                PerformQuery(sqlCmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertItemMeta(Item item, Chain chain)
        {

        }

        public void InsertStoreOfChain(Chain chain)
        {
            try
            {
                string queryString = "INSERT INTO `database`.stores (store_id,chain_id,subchain_id) VALUES (@storeId,@chainId,@subchainId)";
                MySqlCommand sqlCmd = new MySqlCommand(queryString, Connection);
                sqlCmd.Parameters.AddWithValue("@storeId", chain.StoreId);
                sqlCmd.Parameters.AddWithValue("@chainId", chain.ChainId);
                sqlCmd.Parameters.AddWithValue("@subchainId", chain.SubChainId);
                PerformQuery(sqlCmd);
            }
            catch (Exception e)
            {
                throw e;
            }
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
