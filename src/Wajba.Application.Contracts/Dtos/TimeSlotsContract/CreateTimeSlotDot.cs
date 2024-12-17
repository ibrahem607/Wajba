namespace Wajba.Dtos.TimeSlotsContract;

public class CreateTimeSlotDot
{
    [Required]
    public DayOfWeek WeekDay { get; set; }
    [Required]
    public TimeSpan OpeningTime { get; set; }
    [Required]
    public TimeSpan ClosingTime { get; set; }
}
