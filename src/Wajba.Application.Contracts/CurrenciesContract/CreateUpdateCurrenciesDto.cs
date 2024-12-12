using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.CurrenciesContract
{
    public class CreateUpdateCurrenciesDto
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
        public double ExchangeRate { get; set; }
        public bool IsCryptoCurrency { get; set; }
    }
}
