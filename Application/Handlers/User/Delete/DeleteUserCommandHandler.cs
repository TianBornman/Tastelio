using Domain.Repositories;
using MediatR;

namespace Application.Handlers.User.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUnitOfWork uow;

    public DeleteUserCommandHandler(IUnitOfWork uow)
    {
        this.uow = uow;
    }

	public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
        var user = await uow.UserRepository.Get(request.Id);

        if (user == null)
            return;

        await uow.UserRepository.Delete(user);
	}
}
