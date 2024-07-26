using cashFlow.Application.UseCases.Expenses.Create;
using Microsoft.Extensions.DependencyInjection;

namespace cashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
    }
}