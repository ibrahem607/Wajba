global using Wajba.ItemTaxService;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemTaxController : AbpController
{
    private readonly ItemTaxAppService _itemTaxAppService;

    public ItemTaxController(ItemTaxAppService itemTaxAppService)
    {
        _itemTaxAppService = itemTaxAppService;
    }

}