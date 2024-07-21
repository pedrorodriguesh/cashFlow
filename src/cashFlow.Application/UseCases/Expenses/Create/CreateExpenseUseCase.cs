using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase
{
    public ResponseCreatedExpenseJson Execute(RequestCreateExpenseJson request)
    {
        //  TODO: Validations
        
        
        return new ResponseCreatedExpenseJson();
    }
}