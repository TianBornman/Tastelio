using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context;

public class TastelioContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<Reservation> Reservations { get; set; }

	public TastelioContext(DbContextOptions<TastelioContext> contextOptions) : base(contextOptions) { }
}
