using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainingLog.Infrastructure.Context;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Infrastructure.Application.Queries.TrainingLog;

public class GetAllTrainingLogs
{
    public class Query : IRequest<Outcome>
    {
    }
    
    public class Handler: IRequestHandler<Query, Outcome>
    {
        private readonly TrainingLogContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(TrainingLogContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;

        }
    
        public async Task<Outcome> Handle(Query request, CancellationToken cancellationToken)
        {
            var trainingLogs = await _dbContext.TrainingEvents.ToListAsync(cancellationToken);

            return new CommonOutcomes.Success<List<TrainingEventDto>>(_mapper.Map<List<TrainingEventDto>>(trainingLogs));
        }
    }
}