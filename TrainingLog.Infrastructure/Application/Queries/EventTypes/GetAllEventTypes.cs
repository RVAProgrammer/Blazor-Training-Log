using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainingLog.Infrastructure.Context;
using TrainingLog.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Infrastructure.Application.Queries.EventTypes;

public class GetAllEventTypes
{
    public class Query : IRequest<Outcome>
    {
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
            var eventTypes = await _dbContext.EventTypes.ToListAsync(cancellationToken);

            return new CommonOutcomes.Success<List<EventTypeDto>>(_mapper.Map<List<EventTypeDto>>(eventTypes));
        }
    }
}