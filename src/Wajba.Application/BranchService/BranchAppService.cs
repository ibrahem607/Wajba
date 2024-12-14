global using Wajba.Models.BranchDomain;
global using Wajba.Dtos.BranchContract;

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