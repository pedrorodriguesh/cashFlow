using cashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cashFlow.Infrastructure.DataAccess;

// dbContext class to interact with the database using Entity Framework Core
public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; } // Here its defined the table to be used in the database

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // connection to db
    {
        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=pedro123";
        var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}