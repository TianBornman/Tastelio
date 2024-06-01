using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Reservation.Get;

public class GetReservationCommandHandler : IRequestHandler<GetReservationCommand, ReservationDto>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public GetReservationCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<ReservationDto> Handle(GetReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await uow.ReservationRepository.Get(request.Id);

        var user = mapper.Map<ReservationDto>(entity);

        return user;
    }
}
