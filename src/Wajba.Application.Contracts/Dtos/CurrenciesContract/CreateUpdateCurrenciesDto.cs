namespace Wajba.Dtos.CurrenciesContract;

public class CreateUpdateCurrenciesDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Symbol { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public double ExchangeRate { get; set; }
    [Required]
    public bool IsCryptoCurrency { get; set; }
}
