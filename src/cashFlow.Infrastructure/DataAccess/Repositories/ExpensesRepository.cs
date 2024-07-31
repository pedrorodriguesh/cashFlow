using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace cashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository(CashFlowDbContext dbContext) : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository
{
    public async Task Create(Expense expense)
    {
        await dbContext.Expenses.AddAsync(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
        if(result is null) return false;
        
        dbContext.Expenses.Remove(result);

        return true;
    }

    public async Task<List<Expense>> GetAll()
    {
        // AsNoTracking improves performance by not tracking changes to the entities
        return await dbContext.Expenses.AsNoTracking().ToListAsync();
    }
    
    public async Task<Expense?> GetExpenseById(long id)
    {
        return await dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense =>  expense.Id == id) ;
    }
}