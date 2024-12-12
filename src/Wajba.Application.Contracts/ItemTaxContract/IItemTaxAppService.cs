using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wajba.ItemTaxContract
{
    public interface IItemTaxAppService :
    ICrudAppService<
        ItemTaxDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateItemTaxDto>
    {
    }
}
