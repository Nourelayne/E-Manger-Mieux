using System.Security.Claims;
using E_Manger_Mieux.Web.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using Queries;

namespace Controllers;

[ApiController]
[Route("/api/[controller]s")]
public class ProfileController(IMediator mediator) : ControllerBase
{
    [HttpGet("me")]
    public async Task<ActionResult<ProfileDto>> GetProfileAsync()
    {
        var query = new GetProfileQuery { AuthSubject = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value };

        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("me/complete")]
    public async Task<ActionResult<CompleteProfileDto>> CompleteProfileAsync([FromBody] CompleteProfileDto completeProfileDto)
    {
        var authSubject = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (authSubject == null)
        {
            return Unauthorized();
        }
    
        var command = completeProfileDto.ToCompleteProfileCommand(authSubject);
        
        var result = await mediator.Send(command);

        return Ok(result);
    }
}

