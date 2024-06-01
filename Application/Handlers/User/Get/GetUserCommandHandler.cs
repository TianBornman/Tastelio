using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.User.Get;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserDto>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public GetUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await uow.UserRepository.Get(request.Id);

		var user = mapper.Map<UserDto>(entity);

		return user;
    }
}
