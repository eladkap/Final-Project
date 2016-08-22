using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("stores")]
    public class Store
    {
        //public virtual Chain Chain { get; set; }

        //public virtual Subchain Subchain { get; set; }
        [Key]
        [Column("chain_id")]
        public string ChainId { get; set;}

        [Key]
        [Column("subchain_id")]
        public string SubchainId { get; set; }

        [Key]
        [Column("store_id")]
        public int StoreId { get; set; }

        [Column("bikoret_no")]
        public int BikoretNo { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("zipcode")]
        public string Zipcode { get; set; }

        [Column("last_update_date")]
        public string LastUpdateDate { get; set; }

        [Column("last_update_time")]
        public string LastUpdateTime { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}
