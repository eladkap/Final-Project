using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("prices")]
    public class Price
    {
        public virtual Chain Chain { get; set; }

        public virtual Subchain SubChain { get; set; }

        public virtual Store Store { get; set; }

        public virtual Item Item { get; set; }

        [Key]
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }

        [Column("price")]
        public double price { get; set; }

        [Column("allow_discount")]
        public bool AllowDiscount { get; set; }
    }
}
