using AutoMapper;
using cashFlow.Communication.Responses;
using cashFlow.Domain.Repositories.Expenses;

namespace cashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpensesUseCase(IExpensesReadOnlyRepository expensesRepository, IMapper mapper) : IGetAllExpensesUseCase
{

    public async Task<ResponseExpensesJson>  Execute()
    {
        var result = await expensesRepository.GetAll();

        return new ResponseExpensesJson
        {
            Expenses = mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}