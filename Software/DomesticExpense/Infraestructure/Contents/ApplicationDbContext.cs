using DomesticExpense.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomesticExpense.Infraestructure.Contents
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["LocalDbConnection"];
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
