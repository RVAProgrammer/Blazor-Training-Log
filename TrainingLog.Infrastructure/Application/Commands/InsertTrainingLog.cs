using AutoMapper;
using MediatR;
using TrainingLog.Infrastructure.Context;
using TrainingLog.Infrastructure.Models;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Infrastructure.Application.Commands;

public class InsertTrainingLog
{
    public class Command : IRequest<Outcome>
    {
        public NewTrainingEventDto TrainingEvent { get; init; }

        public Command(NewTrainingEventDto trainingEvent)
        {
            TrainingEvent = trainingEvent;
        }
    }

    public class Handler : IRequestHandler<Command, Outcome>
    {
        private readonly TrainingLogContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(TrainingLogContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Outcome> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.TrainingEvent == null)
            {
                throw new ArgumentNullException("request");
            }

            var evnt = new TrainingEvent
            {
                Comments = request.TrainingEvent.Comments ?? "",
                Distance = request.TrainingEvent.Distance,
                Duration = request.TrainingEvent.Duration,
                EventDate = request.TrainingEvent.EventDate,
                EventTitle = request.TrainingEvent.EventTitle,
                EventTypeId = request.TrainingEvent.EventTypeId,
                CreatedBy = "tbecker",
                CreatedDate = DateTime.Now
            };

            await _dbContext.AddAsync(evnt, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CommonOutcomes.Success<TrainingEventDto>(_mapper.Map<TrainingEventDto>(evnt));
        }
    }
}