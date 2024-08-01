using cashFlow.Communication.Requests;

namespace cashFlow.Application.UseCases.Expenses.UpdateExpense;

public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);

}