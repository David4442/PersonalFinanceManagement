using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;
using System.Reflection;

namespace PersonalFinanceManagement.Database
{
    public class TransactionsDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<SubCategoryEntity> SubCategories { get; set; }
        public string DbPath { get; }

        public TransactionsDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "transactions.db");
        }
        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options) : base(options)
        {
            
        }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
            => options.UseSqlite(@"Data Source=C:\Users\Da4e\source\repos\PersonalFinanceManagement\PersonalFinanceManagement\transactions.db");
           
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }
                
        
    }
}
