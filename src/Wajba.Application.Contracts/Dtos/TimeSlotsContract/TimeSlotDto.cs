namespace Wajba.Dtos.TimeSlotsContract;

public class TimeSlotDto : EntityDto<int>
{
    public DayOfWeek WeekDay { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}
