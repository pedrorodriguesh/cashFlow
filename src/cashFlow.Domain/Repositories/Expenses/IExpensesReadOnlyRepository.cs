using cashFlow.Domain.Entities;

namespace cashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetExpenseById(long id);
}