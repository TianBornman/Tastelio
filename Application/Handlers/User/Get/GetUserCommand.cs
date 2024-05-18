using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.User.Get;

public class GetUserCommand : IRequest<UserDto>
{
	public Guid Id { get; set; }
}
