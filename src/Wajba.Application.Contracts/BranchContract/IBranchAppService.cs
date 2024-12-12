using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wajba.BranchContract
{
    public interface IBranchAppService : ICrudAppService<
    BranchDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateBranchDto>
    {
    }
}
