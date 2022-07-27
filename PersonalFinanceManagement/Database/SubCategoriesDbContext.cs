using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagement.Database.Entities;
using PersonalFinanceManagement.Models;
using System.Reflection;

namespace PersonalFinanceManagement.Database
{
    public class SubCategoriesDbContext : DbContext
    {
        public DbSet<SubCategoryEntity> SubCategories { get; set; }
        // public DbSet<Transaction> Transactions { get; set; }
        public string DbPath { get; }

        public SubCategoriesDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "subcategories.db");
        }
        public SubCategoriesDbContext(DbContextOptions options) : base(options)
        {

        }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Da4e\source\repos\PersonalFinanceManagement\PersonalFinanceManagement\subcategories.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

            base.OnModelCreating(modelBuilder);
        }


    }
}
