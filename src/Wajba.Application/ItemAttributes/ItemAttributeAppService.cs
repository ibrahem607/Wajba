using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Wajba.ItemAttributeDomain;

namespace Wajba.ItemAttributes
{
    [RemoteService(false)]
    public class ItemAttributeAppService : CrudAppService<
    ItemAttribute,
    ItemAttributeDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateItemAttributeDto>,
    IItemAttributeAppService
    {
        public ItemAttributeAppService(IRepository<ItemAttribute, int> repository)
            : base(repository)
        {
        }
    }
}