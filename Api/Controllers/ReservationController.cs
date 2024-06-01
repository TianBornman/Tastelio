using Application.Handlers.Reservation.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController] // Indicates that this class is an API controller
[Route("[controller]")] // Sets the base route for this controller to 'Reservation
public class ReservationController : ControllerBase
{
    private readonly ISender mediator;

    public ReservationController(ISender mediator)
    {
        this.mediator = mediator;
    }

    // Action method to handle GET requests for retrieving a reservation by ID
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cToken)
    {
        var command = new GetReservationCommand { Id = id };    // Create a command with the provided reservation ID

        var result = await mediator.Send(command, cToken);  // Send the command via MediatR to get the reservation

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] GetReservationCommand command, CancellationToken cToken)
    {
        var result = await mediator.Send(command, cToken);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] GetReservationCommand command, CancellationToken cToken)
    {
        var result = await mediator.Send(command, cToken);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cToken)
    {
        var command = new GetReservationCommand { Id = id };

        await mediator.Send(command, cToken);

        return Ok();
    }
}
