using Application.DataTransferObjects;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUnitOfWork uow;

    public CreateUserCommandHandler(IUnitOfWork uow)
    {
        this.uow = uow;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.User()
        {
            Email = request.Email,
			FirstName = request.FirstName,
	        LastName = request.LastName,
	        Password = request.Password,
			PasswordSalt = request.PasswordSalt
        };

        await uow.UserRepository.Add(entity);

        await uow.SaveChanges();

		var user = new UserDto()
		{
            Id = entity.Id,
			Email = entity.Email,
			FirstName = entity.FirstName,
			LastName = entity.LastName,
		};

		return user;
    }
}
