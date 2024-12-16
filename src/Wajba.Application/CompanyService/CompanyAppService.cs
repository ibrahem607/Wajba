global using Wajba.Dtos.CompanyContact;
global using Wajba.Models.CompanyDomain;

namespace Wajba.CompanyService;

[RemoteService(false)]
public class CompanyAppService : ApplicationService
{
    private readonly IRepository<Company, int> _repository;
    private readonly IImageService _imageService;

    public CompanyAppService(IRepository<Company, int> repository, IImageService imageService)
    {
        _repository = repository;
        _imageService = imageService;
    }
    public async Task<CompanyDto> CreateAsync(CreateComanyDto input)
    {
        if (input.LogoUrl == null)
            throw new Exception("Image is null");
        Company company = new Company()
        {
            Address = input.Address,
            City = input.City,
            CountryCode = input.CountryCode,
            Email = input.Email,
            Phone = input.Phone,
            Name = input.Name,
            State = input.State,
            ZipCode = input.ZipCode,
            WebsiteURL = input.WebsiteURL,
        };
        try
        {
            string img = await _imageService.UploadAsync(input.LogoUrl);
            company.LogoUrl = img;
        }
        catch (Exception ex)
        {
            throw new Exception("cannot upload image");
        }
        Company company1 = await _repository.InsertAsync(company, true);
        return ObjectMapper.Map<Company, CompanyDto>(company1);
    }
    public async Task<CompanyDto> UpdateAsync(int id, CreateComanyDto input)
    {
        Company company = await _repository.FindAsync(id);
        if (company == null)
            throw new Exception("Not Found");
        company.Address = input.Address;
        company.City = input.City;
        company.CountryCode = input.CountryCode;
        company.Email = input.Email;
        company.Phone = input.Phone;
        company.Name = input.Name;
        company.State = input.State;
        company.ZipCode = input.ZipCode;
        company.WebsiteURL = input.WebsiteURL;
        if (input.LogoUrl != null)
            company.LogoUrl = await _imageService.UploadAsync(input.LogoUrl);
        company.LastModificationTime = DateTime.UtcNow;
        Company company1 = await _repository.UpdateAsync(company, true);
        return ObjectMapper.Map<Company, CompanyDto>(company1);
    }
    public async Task<CompanyDto> GetByIdAsync(int id)
    {
        Company company = await _repository.GetAsync(id);
        return ObjectMapper.Map<Company, CompanyDto>(company);
    }
    public async Task<PagedResultDto<CompanyDto>> GetListAsync(GetComanyInput input)
    {
        var queryable = await _repository.GetQueryableAsync();
        var totalCount = await AsyncExecuter.CountAsync(queryable);
        var companies = await AsyncExecuter.ToListAsync(queryable
             .PageBy(input.SkipCount, input.MaxResultCount));
        return new PagedResultDto<CompanyDto>(
      totalCount,
      ObjectMapper.Map<List<Company>, List<CompanyDto>>(companies)
  );

    }
    public async Task DeleteAsync(int id)
    {
        if (await _repository.FindAsync(id) == null)
            throw new Exception("Not Found");
        await _repository.DeleteAsync(id);
    }
}