using System;
using System.Collections.Generic;
using System.Text;
using AmortizationOSDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace AmortizationOSDatabase
{
    public class AmortizationOSDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AmortizationOSDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<ChartOfAccounts> ChartOfAccounts { set; get; }
        public virtual DbSet<MOL> MOL { set; get; }
        public virtual DbSet<Subdivision> Subdivision { set; get; }
        public virtual DbSet<OS> OS { set; get; }
        public virtual DbSet<Amortization> Amortization { set; get; }
        public virtual DbSet<TransactionsJournal> TransactionsJournal { set; get; }
        public virtual DbSet<AmortizationOS> AmortizationOs { set; get; }
    }
}
