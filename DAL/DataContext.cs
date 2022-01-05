using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL
{
    public class DataContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"DataSource=Data.db;");
        }
    }
}
