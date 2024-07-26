using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Infrastructure.DataAccess;
using cashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace cashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection servicesCollection)
    {
        AddDbContext(servicesCollection);
        AddRepositories(servicesCollection);
    }

    private static void AddRepositories(IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
    private static void AddDbContext(IServiceCollection servicesCollection)
    {
        servicesCollection.AddDbContext<CashFlowDbContext>();
    }
}