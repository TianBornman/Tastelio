using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<TastelioContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("TastelioDb"), b => b.MigrationsAssembly("Api"));
		});

		return services;
	}
}
