using cashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cashFlow.Infrastructure.DataAccess;

// dbContext class to interact with the database using Entity Framework Core
internal class CashFlowDbContext(DbContextOptions options) : DbContext(options)
{
    // Here its defined the table to be used in the database
    public DbSet<Expense> Expenses { get; set; } 
}