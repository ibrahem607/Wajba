global using Wajba.Dtos.ItemAttributes;
using Wajba.ItemAttributes;

namespace Wajba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemAttributeController : AbpController
{
    private readonly ItemAttributeAppService _itemAttributeAppService;

    public ItemAttributeController(ItemAttributeAppService itemAttributeAppService)
    {
      _itemAttributeAppService = itemAttributeAppService;
    }
}