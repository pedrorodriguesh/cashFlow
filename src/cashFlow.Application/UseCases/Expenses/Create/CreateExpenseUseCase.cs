using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using cashFlow.Exception.ExceptionsBase;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase
{
    public ResponseCreatedExpenseJson Execute(RequestCreateExpenseJson request)
    {
        Validate(request);
        
        return new ResponseCreatedExpenseJson();
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