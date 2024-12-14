using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Wajba.CurrenciesContract;
using Wajba.Models.CurrenciesDomain;



namespace Wajba.CurrenciesService
{
    [RemoteService(false)]
    public class CurrenciesAppService : CrudAppService<
    Currencies,
    CurrenciesDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateCurrenciesDto>,
    ICurrenciesAppService
    {
        public CurrenciesAppService(IRepository<Currencies, int> repository)
            : base(repository)
        {
        }
    }
}
