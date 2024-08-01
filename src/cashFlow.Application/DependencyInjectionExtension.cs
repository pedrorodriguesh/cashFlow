using cashFlow.Application.AutoMapper;
using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Application.UseCases.Expenses.DeleteExpense;
using cashFlow.Application.UseCases.Expenses.GetAll;
using cashFlow.Application.UseCases.Expenses.GetExpenseById;
using cashFlow.Application.UseCases.Expenses.UpdateExpense;
using Microsoft.Extensions.DependencyInjection;

namespace cashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
    }
}