namespace TrainingLog.Infrastructure.Models;

public class TrainingEvent
{
    public int TrainingEventId { get; set; }
    public string EventTitle { get; set; }
    public DateTime EventDate { get; set; }
    public int EventTypeId { get; set; }
    public string Duration { get; set; }
    public decimal Distance { get; set; }
    public string Comments { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
}