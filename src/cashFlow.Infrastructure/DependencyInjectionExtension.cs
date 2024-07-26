using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace cashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
}