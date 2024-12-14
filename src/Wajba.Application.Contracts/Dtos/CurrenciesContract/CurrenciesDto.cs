namespace Wajba.Dtos.CurrenciesContract
{
    public class CurrenciesDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
        public double ExchangeRate { get; set; }
        public bool IsCryptoCurrency { get; set; }
    }
}
