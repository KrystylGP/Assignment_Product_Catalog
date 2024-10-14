using Assignment_Product_Catalog.Models;

namespace Assignment_Product_Catalog.Models;

public class Product
{   //Fältar med produktens egenskaper.
    public Guid Id { get; private set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? StockQuantity { get; set; }
    public Product()
    {
        Id = Guid.NewGuid(); //Skapar automatiskt ett unikt ID för produkten.
    }
}
