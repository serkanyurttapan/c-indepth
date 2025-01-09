namespace Services.Products.Update;
public class UpdateProductRequest
{
    public int Id { get; set; }
    public string? Name { get; init; }
    public decimal? Price { get; init; }
    public int? Stock { get; init; }
}