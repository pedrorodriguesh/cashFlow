namespace cashFlow.Domain.Repositories;

public interface IUnitOfWork
{
    void Commit();
}