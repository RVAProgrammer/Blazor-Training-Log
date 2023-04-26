using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainingLog.Infrastructure.Context;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Infrastructure.Application.Queries.TrainingLog;

public class GetTrainingLogById
{
    public class Query : IRequest<Outcome>
    {
        public int TrainingEventId { get; init; }

        public Query(int  trainingEventId)
        {
            TrainingEventId = trainingEventId;
        }
        
    }

    public class Handler : IRequestHandler<Query, Outcome>
    {
        private readonly TrainingLogContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(TrainingLogContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<Outcome> Handle(Query request, CancellationToken cancellationToken)
        {
            var trainingLog = await _dbContext.TrainingEvents.FindAsync(new object[] { request.TrainingEventId },
                cancellationToken: cancellationToken);

            if (trainingLog == null)
            {
                return new CommonOutcomes.NotFound();
            }

            return new CommonOutcomes.Success<TrainingEventDto>(_mapper.Map<TrainingEventDto>(trainingLog));
        }
    }
}