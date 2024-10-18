using Assignment_Product_Catalog.Models;

namespace Assignment_Product_Catalog.Models;

public class Product
{   //Fältar med produktens egenskaper.
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public decimal? Price { get; set; } = null!;
    public int? StockQuantity { get; set; } = 0!;
    public Product()
    {
        Id = Guid.NewGuid(); //Skapar automatiskt ett unikt ID för produkten.
    }
}
