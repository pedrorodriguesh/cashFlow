using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;

namespace cashFlow.Application.UseCases.Expenses.Create;

public interface ICreateExpenseUseCase
{
    ResponseCreatedExpenseJson Execute(RequestCreateExpenseJson request);
}