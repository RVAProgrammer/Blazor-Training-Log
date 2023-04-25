using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingLog.Infrastructure.Application.Queries.TrainingLog;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainingLogController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public TrainingLogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllTrainingLogs.Query());

        return result switch
        {
            CommonOutcomes.Success<List<TrainingEventDto>> response => Ok(response.Data),
            _ => new StatusCodeResult(500)
        };
    }
}