using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Database.Entities;
using System.Reflection;

namespace PersonalFinanceManagement.Database
{
    public class TransactionsDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }
        public string DbPath { get; }

        public TransactionsDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "transactions.db");
        }
        public TransactionsDbContext(DbContextOptions options) : base(options)
        {

        }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>().HasKey(t => t.TransactionId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
