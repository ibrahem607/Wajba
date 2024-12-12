using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
