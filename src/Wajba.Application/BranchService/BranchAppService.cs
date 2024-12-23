global using Wajba.Dtos.BranchContract;
global using Wajba.Models.BranchDomain;

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