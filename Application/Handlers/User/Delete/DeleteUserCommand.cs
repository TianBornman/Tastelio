using MediatR;

namespace Application.Handlers.User.Delete;

public class DeleteUserCommand : IRequest
{
	public Guid Id { get; set; }
}
