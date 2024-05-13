using Application.DataTransferObjects;
using Application.Handlers.User.Create;
using AutoMapper;
using Domain.Entities;

namespace Api.AutoMapper;

public static class AutoMapperConfig
{
	public static IServiceCollection AddAutoMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(Program));

		return services;
	}
}

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		// User
		CreateMap<CreateUserCommand, User>();
		CreateMap<User, UserDto>();

		// Reservation
	}
}