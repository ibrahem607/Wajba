using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wajba.CurrenciesDomain
{
    public class Currencies : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
        public double ExchangeRate { get; set; }
        public bool IsCryptoCurrency { get; set; }
    }
}
