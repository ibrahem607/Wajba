using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Dtos.OTPContract
{
    public interface IOTPAppService : ICrudAppService<
    OTPDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateOTPDto,
    CreateUpdateOTPDto>
    {
    }
}
