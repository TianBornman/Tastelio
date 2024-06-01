using Domain.Repositories;
using Persistance.Context;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TastelioContext dbContext;

    public IUserRepository UserRepository => new UserRepository(dbContext);
    public IReservationRepository ReservationRepository => new ReservationRepository(dbContext);

    public UnitOfWork(TastelioContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
