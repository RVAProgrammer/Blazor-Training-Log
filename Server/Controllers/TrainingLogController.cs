using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainingLog.Infrastructure.Application.Commands;
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

    [HttpGet, Route("id")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetTrainingLogById.Query(id));

        return result switch
        {
            CommonOutcomes.Success<TrainingEventDto> response => Ok(response.Data),
            CommonOutcomes.NotFound _ => NotFound(),
            _ => new StatusCodeResult(500)
        };
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NewTrainingEventDto trainingEvent)
    {
        var result = await _mediator.Send(new InsertTrainingLog.Command(trainingEvent));

        return result switch
        {
            CommonOutcomes.Success<TrainingEventDto> response => Ok(response.Data),
            _ => new StatusCodeResult(500)
        };
    }

}