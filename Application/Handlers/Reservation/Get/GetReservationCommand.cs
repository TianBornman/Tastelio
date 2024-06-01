using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.Reservation.Get;

public class GetReservationCommand : IRequest<ReservationDto>
{
    public Guid Id { get; set; }
}
