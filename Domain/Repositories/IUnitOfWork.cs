namespace Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository UserRepository { get; }
    public IReservationRepository ReservationRepository { get; }

    public Task SaveChanges();
}
