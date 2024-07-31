using AutoMapper;
using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;

namespace cashFlow.Application.UseCases.Expenses.GetExpenseById;

public class GetExpenseByIdUseCase(IExpensesRepository expensesRepository, IMapper mapper) : IGetExpenseByIdUseCase
{
    public async Task<Expense> Execute(long id)
    {
        var expense = await expensesRepository.GetExpenseById(id);

        return mapper.Map<Expense>(expense);
    }
}