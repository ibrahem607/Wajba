global using Wajba.Models.BranchDomain;
global using Wajba.Dtos.BranchContract;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Wajba.BranchService;

[RemoteService(false)]
public class BranchAppService : CrudAppService<
Branch,
BranchDto,
int,
PagedAndSortedResultRequestDto,
CreateUpdateBranchDto>,
IBranchAppService
{
    public BranchAppService(IRepository<Branch, int> repository)
        : base(repository)
    {
    }

}