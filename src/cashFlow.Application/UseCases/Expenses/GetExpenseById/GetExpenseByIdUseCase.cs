using AutoMapper;
using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Exception;
using cashFlow.Exception.ExceptionsBase;

namespace cashFlow.Application.UseCases.Expenses.GetExpenseById;

public class GetExpenseByIdUseCase(IExpensesRepository expensesRepository, IMapper mapper) : IGetExpenseByIdUseCase
{
    public async Task<Expense> Execute(long id)
    {
        var expense = await expensesRepository.GetExpenseById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return mapper.Map<Expense>(expense);
    }
}