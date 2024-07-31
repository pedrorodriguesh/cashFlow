using cashFlow.Domain.Entities;

namespace cashFlow.Application.UseCases.Expenses.GetExpenseById;

public interface IGetExpenseByIdUseCase
{
    public Task<Expense> Execute(long id);
}