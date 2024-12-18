using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wajba.Dtos.OTPContract;
using Wajba.Models.OTPDomain;

namespace Wajba.OTPService
{
    [RemoteService(false)]
    public class OTPAppService : CrudAppService<
    OTP, // The entity
    OTPDto, // DTO for retrieving data
    int, // Primary key type
    PagedAndSortedResultRequestDto, // Paging and sorting
    CreateUpdateOTPDto, // DTO for creating and updating
    CreateUpdateOTPDto>, // DTO for updating
    IOTPAppService // Interface
    {
        public OTPAppService(IRepository<OTP, int> repository)
            : base(repository)
        {
        }
    }
}