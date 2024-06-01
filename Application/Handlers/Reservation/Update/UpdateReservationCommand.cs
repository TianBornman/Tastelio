using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.Reservation.Update;

public class UpdateReservationCommand : IRequest<ReservationDto>
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequests { get; set; } = null!;
    public int? TableNumber { get; set; }
    public TimeSpan? Duration { get; set; }
}
