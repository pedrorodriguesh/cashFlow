using cashFlow.Domain.Entities;

namespace cashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Create(Expense expense);
}