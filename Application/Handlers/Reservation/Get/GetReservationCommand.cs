using Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Reservation.Get
{
    public class GetReservationCommand : IRequest<ReservationDto>
    {
        public Guid Id { get; set; }
    }
}
