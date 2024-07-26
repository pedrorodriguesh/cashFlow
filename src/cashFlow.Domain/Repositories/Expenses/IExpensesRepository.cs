using cashFlow.Domain.Entities;

namespace cashFlow.Domain.Repositories.Expenses;

public interface IExpensesRepository
{ 
    void Create(Expense expense);
}