using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.User.Create;

public class CreateUserCommand : IRequest<UserDto>
{
	public string Email { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public Guid PasswordSalt { get; set; }
}
