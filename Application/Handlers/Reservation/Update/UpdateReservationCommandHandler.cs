using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Reservation.Update
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, ReservationDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UpdateReservationCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ReservationDto> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var entity = await uow.ReservationRepository.Get(request.Id);

            if (entity == null)
                return new();

            entity.StartDate = request.StartDate;
            entity.EndDate = request.StartDate;
            entity.NumberOfGuests = request.NumberOfGuests;
            entity.SpecialRequests = request.SpecialRequests;
            entity.TableNumber = request.TableNumber;
            entity.Duration = request.Duration;

            await uow.ReservationRepository.Update(entity);

            var user = mapper.Map<ReservationDto>(entity);

            return user;
        }
    }
}
