using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.User.Update;

public class UpdateUserCommand : IRequest<UserDto>
{
	public Guid Id { get; set; }
	public string Email { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public Guid PasswordSalt { get; set; }
}
