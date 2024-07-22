using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseUseCase
{
    public ResponseCreatedExpenseJson Execute(RequestCreateExpenseJson request)
    {
        //  TODO: Validations
        Validate(request);
        
        return new ResponseCreatedExpenseJson();
    }


    private static void Validate(RequestCreateExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);

        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        if (result > 0)
        {
            throw new ArgumentException("Date must be less than or equal to the current date");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (!paymentTypeIsValid)
        {
            throw new ArgumentException("Payment type is not valid.");
        }
    }
}