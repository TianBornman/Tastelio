using Application.DataTransferObjects;
using MediatR;

namespace Application.Handlers.Reservation.Create;

public class CreateReservationCommand : IRequest<ReservationDto>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfGuests { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string SpecialRequests { get; set; } = null!;
    public int? TableNumber { get; set; }
    public TimeSpan? Duration { get; set; }
}
