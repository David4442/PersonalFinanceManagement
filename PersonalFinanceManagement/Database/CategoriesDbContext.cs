using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Models;
using System.Reflection;

namespace PersonalFinanceManagement.Database
{
    public class CategoriesDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
       // public DbSet<Transaction> Transactions { get; set; }
        public string DbPath { get; }

        public CategoriesDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "categories.db");
        }
        public CategoriesDbContext(DbContextOptions options) : base(options)
        {

        }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Da4e\source\repos\PersonalFinanceManagement\PersonalFinanceManagement\categories.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Category>().HasKey(c=>c.Code);
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
