using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalLab
{
    [XmlRoot("root")]
    public class Chain
    {
        [XmlElement("ChainId")]
        public string ChainId { get; set; }

        [XmlElement("SubChainId")]
        public string SubChainId { get; set; }

        [XmlElement("StoreId")]
        public string StoreId { get; set; }

        [XmlElement("BikoretNo")]
        public int BikoretNo { get; set; }

        [XmlElement("DllVerNo")]
        public string DllVerNo { get; set; }

        [XmlArray("Items")]
        public Item[] Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ChainId}, {SubChainId}, {StoreId},");
            Items.ToList().ForEach((item) => sb.AppendLine($"\t{item.ToString()}\n"));
            return sb.ToString();
        }
    }
}