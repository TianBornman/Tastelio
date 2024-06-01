using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public UpdateUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await uow.UserRepository.Get(request.Id);

        if (entity == null)
            return new();

		entity.Email = request.Email;
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Password = request.Password;
        entity.PasswordSalt = request.PasswordSalt;
        entity.ModifiedDate = DateTime.Now;

	    await uow.UserRepository.Update(entity);

		var user = mapper.Map<UserDto>(entity);

		return user;
    }
}
