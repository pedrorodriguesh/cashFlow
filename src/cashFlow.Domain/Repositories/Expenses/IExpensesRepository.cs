using cashFlow.Domain.Entities;

namespace cashFlow.Domain.Repositories.Expenses;

public interface IExpensesRepository
{ 
    Task Create(Expense expense);
    Task<List<Expense>> GetAll();
    Task<Expense?> GetExpenseById(long id);
}