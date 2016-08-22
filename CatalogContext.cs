namespace FinalLab
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CatalogContext : DbContext
    {
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Subchain> Subchains { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
    }

}