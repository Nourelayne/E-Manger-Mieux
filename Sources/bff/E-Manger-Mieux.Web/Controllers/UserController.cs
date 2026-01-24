using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using Queries;

namespace Controllers;

[ApiController]
[Route("/api/[controller]s")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetUserAsync()
    {
        var query = new GetUserQuery { AuthSubject = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value };

        var result = await mediator.Send(query);

        return Ok(result);
    }
}
