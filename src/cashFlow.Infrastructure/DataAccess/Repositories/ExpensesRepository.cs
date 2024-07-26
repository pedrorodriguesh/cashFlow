using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;

namespace cashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesRepository
{
    public void Create(Expense expense)
    {
        var dbContext = new CashFlowDbContext();
        
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
    }
}