using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TastelioContext dbContext;

    public UserRepository(TastelioContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(User entity)
    {
        await dbContext.Users.AddAsync(entity);
		await dbContext.SaveChangesAsync();
	}

    public async Task Delete(User entity)
    {
        dbContext.Users.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> Get(Guid id)
    {
        return await dbContext.Users.SingleAsync(user => user.Id == id);
    }

    public async Task<IEnumerable<User>> Get(IEnumerable<Guid> ids)
    {
        return await dbContext.Users.Where(user => ids.Contains(user.Id)).ToListAsync();
    }

    public async Task Update(User entity)
    {
        dbContext.Update(entity);
		await dbContext.SaveChangesAsync();
	}
}
