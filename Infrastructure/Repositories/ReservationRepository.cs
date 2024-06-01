using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly TastelioContext dbContext;

    public ReservationRepository(TastelioContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Add(Reservation entity)
    {
        await dbContext.Reservations.AddAsync(entity);  //asynchronously adds the specified Reservation entity to the DbSet
        await dbContext.SaveChangesAsync(); //Update starts running
    }

    public async Task Update(Reservation entity)
    {
        dbContext.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Reservation entity)
    {
        dbContext.Reservations.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    //asynchronously retrieves a single Reservation object from the database based on the provided id
    public async Task<Reservation?> Get(Guid id)
    {
        return await dbContext.Reservations.SingleAsync(Reservation => Reservation.Id == id);
    }

    //asynchronously retrieves multiple Reservation objects from the database based on the provided collection of ids.
    public async Task<IEnumerable<Reservation>> Get(IEnumerable<Guid> ids)
    {
        return await dbContext.Reservations.Where(Reservation => ids.Contains(Reservation.Id)).ToListAsync();
    }
}
