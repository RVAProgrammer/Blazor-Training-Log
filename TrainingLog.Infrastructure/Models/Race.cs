using System.Runtime.InteropServices.JavaScript;

namespace TrainingLog.Infrastructure.Models;

public class Race
{
    public int RaceId { get; set; }
    public string RaceName { get; set; }
    public string RaceUrl { get; set; }
    public decimal Distance { get; set; }
    public int? LogEventId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
}