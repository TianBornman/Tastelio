using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public CreateUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.User>(request);

        await uow.UserRepository.Add(entity);

		var user = mapper.Map<UserDto>(entity);

		return user;
    }
}
