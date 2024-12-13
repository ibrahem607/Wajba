using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Wajba.BranchContract;
using Wajba.BranchDomain;

namespace Wajba.BranchService
{
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
}