namespace Wajba.Dtos.TimeSlotsContract;

public class CreateTimeSlotDot
{
    public DayOfWeek WeekDay { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}
