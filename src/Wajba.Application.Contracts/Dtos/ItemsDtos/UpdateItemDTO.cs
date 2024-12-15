namespace Wajba.Dtos.ItemsDtos;

public sealed record UpdateItemDTO
{

    public int Id { get; set; }
    public string Name { get; set; }
    public IFormFile? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool IsFeatured { get; set; }
    public int status { get; set; }
    public int ItemType { get; set; }
    public string Note { get; set; }
    public string Description { get; set; }
    public decimal? TaxValue { get; set; }
    public int CategoryId { get; set; }


}