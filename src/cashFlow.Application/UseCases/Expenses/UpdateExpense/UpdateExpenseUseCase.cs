using AutoMapper;
using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Requests;
using cashFlow.Domain.Repositories;
using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Exception;
using cashFlow.Exception.ExceptionsBase;

namespace cashFlow.Application.UseCases.Expenses.UpdateExpense;

public class UpdateExpenseUseCase(IMapper mapper, IUnitOfWork unitOfWork, IExpensesUpdateOnlyRepository repository) : IUpdateExpenseUseCase
{
    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await repository.GetExpenseById(id);
        
        if(expense is null) throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        mapper.Map(request, expense);
        repository.Update(expense);

        await unitOfWork.Commit();
    }
    
    private static void Validate(RequestExpenseJson request)
    {
        // using FluentValidation to validate the request
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}