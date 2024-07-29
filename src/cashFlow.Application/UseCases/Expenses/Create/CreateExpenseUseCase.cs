using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using cashFlow.Domain.Entities;
using cashFlow.Domain.Entities.Enums;
using cashFlow.Domain.Repositories;
using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Exception.ExceptionsBase;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase(IExpensesRepository expensesRepository, IUnitOfWork unitOfWork) : ICreateExpenseUseCase
{
    public async Task<ResponseCreatedExpenseJson>  Execute(RequestCreateExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (PaymentType)request.PaymentType,
        };
        
        await expensesRepository.Create(entity);
        await unitOfWork.Commit();
        
        return new ResponseCreatedExpenseJson
        {
            Title = request.Title
        };
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