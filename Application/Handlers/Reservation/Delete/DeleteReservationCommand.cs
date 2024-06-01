using MediatR;

namespace Application.Handlers.Reservation.Delete;

public class DeleteReservationCommand : IRequest
{
    public Guid Id { get; set; }
}
