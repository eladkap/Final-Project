using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab
{
    [Table("subchains")]
    public class Subchain
    {
        public Subchain()
        {
            Stores = new List<Store>();
        }

        [Key]
        [Column("subchain_id")]
        public string SubchainId { get; set; }

        [Column("subchain_name")]
        public string SubchainName { get; set; }

        public virtual List<Store> Stores { get; set; }
    }
}
