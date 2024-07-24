using cashFlow.Communication.Requests;
using cashFlow.Exception;
using FluentValidation;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseValidator : AbstractValidator<RequestCreateExpenseJson>
{
    public CreateExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATE_MUST_BE_IN_FUTURE);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}