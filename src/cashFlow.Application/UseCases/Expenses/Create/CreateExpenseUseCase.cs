using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase
{
    public ResponseCreatedExpenseJson Execute(RequestCreateExpenseJson request)
    {
        Validate(request);
        
        return new ResponseCreatedExpenseJson();
    }


    private static void Validate(RequestCreateExpenseJson request)
    {
        var validator = new CreateExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
    }
}