using cashFlow.Communication.Responses;

namespace cashFlow.Application.UseCases.Expenses.GetAll;

public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesJson> Execute();
}