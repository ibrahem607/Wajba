using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Wajba.ItemTaxContract;
using Wajba.ItemTaxDomain;

namespace Wajba.ItemTaxService
{
    [RemoteService(false)]
    public class ItemTaxAppService : CrudAppService<
    ItemTax,
    ItemTaxDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateItemTaxDto>,
    IItemTaxAppService
    {
        public ItemTaxAppService(IRepository<ItemTax, int> repository)
            : base(repository)
        {
        }
    }
}