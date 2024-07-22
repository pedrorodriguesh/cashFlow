using cashFlow.Communication.Enums;
using cashFlow.Communication.Requests;
using FluentValidation;

namespace cashFlow.Application.UseCases.Expenses.Create;

public class CreateExpenseValidator : AbstractValidator<RequestCreateExpenseJson>
{
    public CreateExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount must be greater than zero.");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The date must be in the future.");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("The Payment Type is not valid.");
    }
}