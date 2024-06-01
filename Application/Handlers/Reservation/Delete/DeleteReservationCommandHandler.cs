using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Reservation.Delete;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IUnitOfWork uow;

    public DeleteReservationCommandHandler(IUnitOfWork uow)
    {
        this.uow = uow;
    }

    public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var user = await uow.ReservationRepository.Get(request.Id);

        if (user == null)
            return;

        await uow.ReservationRepository.Delete(user);
    }
}
