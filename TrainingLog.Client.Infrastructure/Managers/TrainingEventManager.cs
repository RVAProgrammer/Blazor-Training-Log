using System.Net.Http.Json;
using TrainingLog.Client.Infrastructure.Endpoints;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Client.Infrastructure.Managers;

public interface ITrainingEventManager
{
    Task<List<TrainingEventDto>?> GetAllTrainingEvents();
    Task<List<EventTypeDto>> GetEventTypes();
    Task<bool> InsertTrainingEvent(NewTrainingEventDto newTrainingEvent);
}

public class TrainingEventManager :ITrainingEventManager
{
    private readonly HttpClient _httpClient;
    public TrainingEventManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<TrainingEventDto>?> GetAllTrainingEvents() =>
        await _httpClient.GetFromJsonAsync<List<TrainingEventDto>>(TrainingEventEndpoints.Base());
    
    public async Task<List<EventTypeDto>> GetEventTypes() =>
        await _httpClient.GetFromJsonAsync<List<EventTypeDto>>(LookupEndpoints.GetAllEventTypes);

   public async Task<bool> InsertTrainingEvent(NewTrainingEventDto newTrainingEvent)
   {
       var result = await _httpClient.PostAsJsonAsync(TrainingEventEndpoints.Base(), newTrainingEvent);

       result.EnsureSuccessStatusCode();
       return true;//todo
   }
}