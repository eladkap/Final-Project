using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ShowChainDetailsAndItems(Chain chain)
        {
            listbox_chain.Items.Clear();
            listbox_chain.Items.Add(chain.ChainId);
            listbox_chain.Items.Add(chain.SubChainId);
            listbox_chain.Items.Add(chain.StoreId);
            listbox_chain.Items.Add(chain.DllVerNo);
            listbox_chain.Items.Add(chain.BikoretNo.ToString());

            listbox_items.Items.Clear();
            foreach (var item in chain.Items)
            {
                listbox_items.Items.Add(item.ToString());
            }
            txt_itemsNum.Text = listbox_items.Items.Count.ToString();
        }

        private void btn_testXml_Click(object sender, EventArgs e)
        {
            XmlDecoder xmlDecoder = new XmlDecoder();
            Chain chain = xmlDecoder.DeserializeChain(@"D:\files\Prices\Price7290027600007-001-201607262230\Price7290027600007-001-201607262230.xml");
            ShowChainDetailsAndItems(chain);
        }

        /// <summary>
        /// Insert chain details into all relevant tables: items, stores, etc...
        /// </summary>
        /// <param name="chain"></param>
        private void InsertChainDetailsIntoDatabase(Chain chain)
        {
            try
            {
                QueryBuilder queryBuilder = new QueryBuilder();
                queryBuilder.InsertStoreOfChain(chain);
                MessageBox.Show($"Updating {chain.Items.Count()} items...");
                foreach (var item in chain.Items)
                {
                    queryBuilder.InsertItem(item, chain);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show("Error: Database is down.", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirPath">Root directory from which to collect xml files</param>
        /// <param name="filesNumber">Number of files to be updated.</param>
        private void UpdateCatalog(string dirPath, int filesNumber)
        {
            XmlDecoder xmlDecoder = new XmlDecoder();
            string[] filePaths = filePaths = Directory.GetFiles(dirPath, "*.xml", SearchOption.AllDirectories);
            MessageBox.Show($"filePaths number :  #{filePaths.Count()}");
            int filesCounter = 0;
            foreach (var filePath in filePaths)
            {
                Chain chain = xmlDecoder.DeserializeChain(filePath);
                InsertChainDetailsIntoDatabase(chain);
                MessageBox.Show($"file #{filesCounter + 1} updated.");
                filesCounter++;
                if (filesCounter == filesNumber)
                {
                    break;
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCatalog(Constants.XmlPricesDirPath, Constants.XmlFilesNumber);
            MessageBox.Show("Catalog was updated successfully.", "Update catalog", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
