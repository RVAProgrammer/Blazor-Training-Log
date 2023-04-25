namespace TrainingLog.Infrastructure.Models;

public class EventType
{
    public int EventTypeId { get; set; }
    public string EventTypeName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    
}