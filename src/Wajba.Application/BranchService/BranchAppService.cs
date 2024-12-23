global using Wajba.Models.BranchDomain;
global using Wajba.Dtos.BranchContract;

namespace Wajba.BranchService;

[RemoteService(false)]
public class BranchAppService : ApplicationService
{
    private readonly IRepository<Branch, int> _repository;

    public BranchAppService(IRepository<Branch, int> repository)
    {
      _repository = repository;
    }
    public async Task<BranchDto> CreateAsync(CreateUpdateBranchDto input)
    {
        Branch branch = new Branch
        {
            Name = input.Name,
            Address = input.Address,
            City = input.City,
            Email = input.Email,
            Phone = input.Phone,
            ZipCode = input.ZipCode,
            State = input.State,
            Longitude = input.Longitude,
            Latitude = input.Latitude,
            Status = input.Status
        };
        Branch branch1 = await _repository.InsertAsync(branch);
        return ObjectMapper.Map<Branch, BranchDto>(branch1);
    }
    public async Task<BranchDto> UpdateAsync(int id, CreateUpdateBranchDto input)
    {
        Branch branch = await _repository.GetAsync(id);
        branch.Name = input.Name;
        branch.Longitude = input.Longitude;
        branch.Status = input.Status;
        branch.Latitude = input.Latitude;
        branch.Phone = input.Phone;
        branch.Address = input.Address;
        branch.City = input.City;
        branch.Email = input.Email;
        branch.State = input.State;
        branch.ZipCode = input.ZipCode;
        branch.LastModificationTime = DateTime.UtcNow;
        Branch branch1 = await _repository.UpdateAsync(branch);
        return ObjectMapper.Map<Branch, BranchDto>(branch1);
    }
    public async Task<PagedResultDto<BranchDto>> GetListAsync(GetBranchInput input)
    {
        IQueryable<Branch> queryable = await _repository.GetQueryableAsync();
        var result = await AsyncExecuter.ToListAsync(queryable);
        int totalCount = await AsyncExecuter.CountAsync(queryable);
        return new PagedResultDto<BranchDto>(
            totalCount,
            ObjectMapper.Map<List<Branch>, List<BranchDto>>(result)
        );
    }

    public async Task<BranchDto> GetByIdAsync(int id)
    {
        Branch branch = await _repository.GetAsync(id);
        return ObjectMapper.Map<Branch, BranchDto>(branch);
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}