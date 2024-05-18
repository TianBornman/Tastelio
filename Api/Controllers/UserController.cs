using Application.Handlers.User.Create;
using Application.Handlers.User.Delete;
using Application.Handlers.User.Get;
using Application.Handlers.User.Update;
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

	[HttpGet("get/{id}")]
	public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cToken)
	{
		var command = new GetUserCommand { Id = id };

		var result = await mediator.Send(command, cToken);

		return Ok(result);
	}	
	
	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cToken)
	{
		var result = await mediator.Send(command, cToken);

		return Ok(result);
	}	
	
	[HttpPut("update")]
	public async Task<IActionResult> Create([FromBody] UpdateUserCommand command, CancellationToken cToken)
	{
		var result = await mediator.Send(command, cToken);

		return Ok(result);
	}	
	
	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cToken)
	{
		var command = new DeleteUserCommand { Id= id };

		await mediator.Send(command, cToken);

		return Ok();
	}
}
