global using Wajba.Dtos.TimeSlotsContract;
global using Wajba.Models.TimeSlotsDomain;
global using System;

namespace Wajba.TimeSlotsServices;

[RemoteService(false)]
public class TimeSlotsAppservice:ApplicationService
{
    private readonly IRepository<TimeSlot,int> _repository;

    public TimeSlotsAppservice(IRepository<TimeSlot, int> repository)
    {
        _repository = repository;
    }
    public async Task<TimeSlotDto> CreateAsync(CreateTimeSlotDot input)
    {
        TimeSlot timeSlot = new TimeSlot()
        {
            ClosingTime = input.ClosingTime,
            OpeningTime = input.OpeningTime,
            WeekDay = input.WeekDay,
            IsDeleted = false,
        };
        TimeSlot timeSlot1 = await _repository.InsertAsync(timeSlot, true);
        return ObjectMapper.Map<TimeSlot, TimeSlotDto>(timeSlot1);
    }
    public async Task<TimeSlotDto> UpdateAsync(int id, CreateTimeSlotDot input)
    {
        TimeSlot timeSlot = await _repository.GetAsync(id);
        if (timeSlot == null)
            return null;
        timeSlot.ClosingTime = input.ClosingTime;
        timeSlot.OpeningTime = input.OpeningTime;
        timeSlot.WeekDay = input.WeekDay;
        timeSlot.IsDeleted = false;
        timeSlot.LastModificationTime = DateTime.UtcNow;
        TimeSlot timeSlot1 = await _repository.UpdateAsync(timeSlot, true);
        return ObjectMapper.Map<TimeSlot, TimeSlotDto>(timeSlot1);
    }
    public async Task<TimeSlotDto> GetByIdAsync(int id)
    {
        TimeSlot timeSlot= await _repository.GetAsync(id);
        return ObjectMapper.Map<TimeSlot, TimeSlotDto>(timeSlot);
    }
    public async Task<PagedResultDto<TimeSlotDto>> GetListAsync(GetTimeSlotInput input)
    {
        var queryable = await _repository.GetQueryableAsync();
        var totalCount = await AsyncExecuter.CountAsync(queryable);
        var timeSlots = await AsyncExecuter.ToListAsync(queryable
           //.OrderBy(input.Sorting ?? nameof(Category.Name))
           .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<TimeSlotDto>(
      totalCount,
      ObjectMapper.Map<List<TimeSlot>, List<TimeSlotDto>>(timeSlots)
  );
    }
    public async Task DeleteAsync(int id)
    {
        if (await _repository.FindAsync(id) == null)
            throw new Exception("Not Found");
        await _repository.DeleteAsync(id);
    }
}
