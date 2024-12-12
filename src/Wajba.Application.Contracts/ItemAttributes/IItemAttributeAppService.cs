using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wajba.ItemAttributes
{
    public interface IItemAttributeAppService :
    ICrudAppService<
        ItemAttributeDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateItemAttributeDto>
    {
    }
}
