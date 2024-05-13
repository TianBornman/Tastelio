using Application.Handlers.User.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly ISender mediator;

	public UserController(ISender mediator)
	{
		this.mediator = mediator;
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cToken)
	{
		var result = await mediator.Send(command, cToken);

		return Ok(result);
	}
}
