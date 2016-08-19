using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalLab
{
    [XmlRoot("Item")]
    public class Item
    {

        [XmlElement("PriceUpdateDate")]
        public string PriceUpdateDate { get; set; }

        [XmlElement("ItemCode")]
        public string ItemCode { get; set; }

        [XmlElement("ItemType")]
        public int ItemType { get; set; }

        [XmlElement("ItemName")]
        public string ItemName { get; set; }

        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [XmlElement("ManufactureCountry")]
        public string ManufactureCountry { get; set; }

        [XmlElement("ManufacturerItemDescription")]
        public string ManufacturerItemDescription { get; set; }

        [XmlElement("UnitQty")]
        public string UnitQty { get; set; }

        [XmlElement("Quantity")]
        public double Quantity { get; set; }

        [XmlElement("bIsWeighted")]
        public bool bIsWeighted { get; set; }

        [XmlElement("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [XmlElement("QtyInPackage")]
        public int QtyInPackage { get; set; }

        [XmlElement("ItemPrice")]
        public double ItemPrice { get; set; }

        [XmlElement("UnitOfMeasurePrice")]
        public double UnitOfMeasurePrice { get; set; }

        [XmlElement("AllowDiscount")]
        public bool AllowDiscount { get; set; }

        [XmlElement("ItemStatus")]
        public int ItemStatus { get; set; }

        public override string ToString()
        {
            return $"[{PriceUpdateDate},{ItemCode},{ItemType},{ItemName},{ManufacturerName},{ManufactureCountry},{ManufacturerItemDescription},{Quantity},{ItemPrice},{ItemStatus}]";
        }

    }
}
