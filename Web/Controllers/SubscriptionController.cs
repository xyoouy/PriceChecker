using Application.Commands.Subscribe;
using Application.Queries.GetApartmentInfo;
using Application.Views;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private IMediator? mediator;
    private IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    [HttpGet("getInfos")]
    public async Task<ActionResult<IList<ApartmentInfo>>> GetInfo([FromQuery] GetApartmentInfoQuery query)
    {
        try
        {
            var apartmentInfos = await Mediator.Send(query);
            return Ok(apartmentInfos);
        }
        catch
        {
            return Ok(null);
        }
        
    }

    [HttpPost("subscribe")]
    public async Task<ActionResult<int>> CreateUser([FromBody] SubscribeCommand command)
    {
        try
        {
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }
        catch (Exception ex)
        {
            return Forbid();
        }
       
    }
}