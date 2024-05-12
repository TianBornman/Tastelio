namespace Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository UserRepository { get; }

    public Task SaveChanges();
}
