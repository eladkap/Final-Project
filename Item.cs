using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("items")]
    public class Item
    {
        [Key]
        [Column("item_code")]
        public string ItemCode { get; set; }

        [Column("item_type")]
        public int ItemType { get; set; }

        [Column("item_name")]
        public string ItemName { get; set; }

        [Column("manufacturer_name")]
        public string ManufacturerName { get; set; }

        [Column("manufacturer_country")]
        public string ManufacturerCountry { get; set; }

        [Column("manufacturer_item_description")]
        public string ManufacturerItemDescription { get; set; }

        [Column("unit_quantity")]
        public string UnitQty { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("is_weighted")]
        public bool bIsWeighted { get; set; }

        [Column("unit_of_measure")]
        public string UnitOfMeasure { get; set; }

        [Column("quantity_in_package")]
        public int QtyInPackage { get; set; }

        public virtual List<Price> Prices { get; set; }
    }
}
