using AutoMapper;
using TrainingLog.Infrastructure.Models;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Infrastructure.Mappings;

public class TrainingLogMappings: Profile
{
    public TrainingLogMappings() 
    {
        CreateMap<TrainingEvent, TrainingEventDto>();
            
    }
}