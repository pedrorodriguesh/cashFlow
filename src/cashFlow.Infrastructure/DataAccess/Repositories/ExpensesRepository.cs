using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;

namespace cashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository(CashFlowDbContext dbContext) : IExpensesRepository
{
    public void Create(Expense expense)
    {
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
    }
}