using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingLog.Infrastructure.Application.Queries.EventTypes;
using TrainingLog.Infrastructure.Application.Queries.TrainingLog;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllEventTypes.Query());

        return result switch
        {
            CommonOutcomes.Success<List<EventTypeDto>> response => Ok(response.Data),
            _ => new StatusCodeResult(500)
        };
    }
}