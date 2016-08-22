using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace FinalLab
{
    public class QueryBuilder
    {
        private DatabaseConnector _connector;

        public QueryBuilder()
        {
            _connector = new DatabaseConnector();
        }

        public SqlConnection Connection { get { return _connector.Connection; } }

        private void PerformQuery(SqlCommand sqlCmd)
        {
            _connector.ConnectToDatabase();
            using (SqlTransaction transaction = Connection.BeginTransaction())
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
                string insertString = "INSERT INTO `db`.items (item_code,item_type,item_name,manufacturer_name,manufacturer_country,manufacturer_item_description,unit_quantity,quantity,is_weighted,unit_of_measure,quantity_in_package) ";
                string valuesString = "VALUES (@item_code,@item_type,@item_name,@manufacturer_name,@manufacturer_country,@manufacturer_item_description,@unit_quantity,@quantity,@is_weighted,@unit_of_measure,@quantity_in_package)";
                string queryString = insertString + valuesString;
                SqlCommand sqlCmd = new SqlCommand(queryString, Connection);
                sqlCmd.Parameters.AddWithValue("@item_code", item.ItemCode);
                sqlCmd.Parameters.AddWithValue("@item_type", item.ItemType);
                sqlCmd.Parameters.AddWithValue("@item_name", item.ItemName);
                sqlCmd.Parameters.AddWithValue("@manufacturer_name", item.ManufacturerName);
                sqlCmd.Parameters.AddWithValue("@manufacturer_country", item.ManufacturerCountry);
                sqlCmd.Parameters.AddWithValue("@manufacturer_item_description", item.ManufacturerItemDescription);
                sqlCmd.Parameters.AddWithValue("@unit_quantity", item.UnitQty);
                sqlCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                sqlCmd.Parameters.AddWithValue("@is_weighted", item.bIsWeighted);
                sqlCmd.Parameters.AddWithValue("@unit_of_measure", item.UnitOfMeasure);
                sqlCmd.Parameters.AddWithValue("@quantity_in_package", item.QtyInPackage);
                PerformQuery(sqlCmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertPrice(Item item, Chain chain)
        {
            using (CatalogContext context = new CatalogContext())
            {
                //context.
            }
        }

        public void InsertStore()
        {
            using (CatalogContext context = new CatalogContext())
            {
                Chain chain = new Chain
                {
                    ChainId = "12345678",
                    ChainName = "SomeChain",
                    ChainNameHebrew = "sommmechain"
                };
                Subchain subchain = new Subchain
                {
                    SubchainId = "1",
                    SubchainName = "Shufersal Deal",
                };
                Store store = new Store()
                {
                    ChainId = chain.ChainId,
                    SubchainId = subchain.SubchainId,
                    StoreId = 121,
                    Address = "Herzel 12",
                    City = "Nahariya",
                    Zipcode = "324657",
                    BikoretNo = 3
                };
                context.Stores.Add(store);
                context.SaveChanges();
            }
        }

        public void InsertChain()
        {
            using (CatalogContext context = new CatalogContext())
            {
                Chain chain = new Chain
                {
                    ChainId = "12345678",
                    ChainName = "SomeChain",
                    ChainNameHebrew = "sommmechain"
                };
                context.Chains.Add(chain);
                context.SaveChanges();
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
