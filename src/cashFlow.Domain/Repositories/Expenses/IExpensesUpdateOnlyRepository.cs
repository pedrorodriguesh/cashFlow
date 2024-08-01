using cashFlow.Domain.Entities;

namespace cashFlow.Domain.Repositories.Expenses;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetExpenseById(long id);
    void Update(Expense expense);
}