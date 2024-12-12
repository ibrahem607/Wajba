using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Wajba.CurrenciesContract
{
    public interface ICurrenciesAppService :
    ICrudAppService<
        CurrenciesDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateCurrenciesDto>
    {
    }
}
