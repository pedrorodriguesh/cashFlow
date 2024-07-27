using cashFlow.Domain.Repositories;

namespace cashFlow.Infrastructure.DataAccess;

internal class UnitOfWork(CashFlowDbContext dbContext) : IUnitOfWork
{
    public void Commit() => dbContext.SaveChanges();
}