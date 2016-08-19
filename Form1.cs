using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Chain chain = xmlDecoder.DeserializeChain(@"D:\files\Shufersal\Prices\Price7290027600007-001-201607262230\Price7290027600007-001-201607262230.xml");
            ShowChainDetailsAndItems(chain);
        }
    }
}
