using cashFlow.Domain.Repositories;
using cashFlow.Domain.Repositories.Expenses;
using cashFlow.Infrastructure.DataAccess;
using cashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        AddDbContext(servicesCollection, configuration);
        AddRepositories(servicesCollection);
    }

    private static void AddRepositories(IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        servicesCollection.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        servicesCollection.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        servicesCollection.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
    }
    private static void AddDbContext(IServiceCollection servicesCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        
        var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));
        // optionsBuilder.UseMySql(connectionString, serverVersion);
        
        servicesCollection.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}