using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;

namespace cashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository(CashFlowDbContext dbContext) : IExpensesRepository
{
    public async Task Create(Expense expense)
    {
        await dbContext.Expenses.AddAsync(expense);
    }
}