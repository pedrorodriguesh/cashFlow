using AutoMapper;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using cashFlow.Domain.Entities;
using cashFlow.Domain.Repositories;
using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Exception.ExceptionsBase;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase(
    IExpensesWriteOnlyRepository expensesRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICreateExpenseUseCase
{
    public async Task<ResponseCreatedExpenseJson>  Execute(RequestCreateExpenseJson request)
    {
        Validate(request);

        // using mapper package.
        var entity = mapper.Map<Expense>(request);
        
        await expensesRepository.Create(entity);
        await unitOfWork.Commit();
        
        return mapper.Map<ResponseCreatedExpenseJson>(entity);
    }


    // auxiliary function to validate the request
    private static void Validate(RequestCreateExpenseJson request)
    {
        // using FluentValidation to validate the request
        var validator = new CreateExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}