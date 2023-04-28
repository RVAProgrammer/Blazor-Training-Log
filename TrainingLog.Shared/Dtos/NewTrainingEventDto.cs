using System.ComponentModel.DataAnnotations;

namespace TrainingLog.Shared.Dtos;

public class NewTrainingEventDto
{
    [Required]
    public string EventTitle { get; set; }
    public DateTime EventDate { get; set; }
    public int EventTypeId { get; set; }
    [Required]
    public string Duration { get; set; }
    public decimal Distance { get; set; }
   
    [MaxLength(20, ErrorMessage = "Keep it brief buddy")] //TODO
    public string? Comments { get; set; }

}