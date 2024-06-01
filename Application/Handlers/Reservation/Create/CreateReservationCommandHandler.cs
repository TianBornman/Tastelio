using Application.DataTransferObjects;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Reservation.Create;

//the class handles requests from both CreateReservationCommand and ReservationDto
public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationDto>
{
    private readonly IUnitOfWork uow;   //a common design pattern for managing database transactions and repositories.
    private readonly IMapper mapper; //object-object mapping.

    //constructor accepts two parameters and These parameters are assigned to the class fields.
    public CreateReservationCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Reservation>(request);  //Maps the CreateReservationCommand to a Reservation entity.

        await uow.ReservationRepository.Add(entity);    //Adds the newly created Reservation entity to the repository. This step is asynchronous.

        var reservation = mapper.Map<ReservationDto>(entity); //Maps the saved Reservation entity to a ReservationDto.

        return reservation;
    }
}
