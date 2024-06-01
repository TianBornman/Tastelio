using Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Reservation.Create
{
    public class CreateReservationCommand : IRequest<ReservationDto>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string ReservationStatus { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string SpecialRequests { get; set; } = null!;
        public int? TableNumber { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
