using Assignment_Product_Catalog.Models;

namespace Assignment_Product_Catalog.Services;
public class ProductService
{
    private List<Product> products { get; set; }

    public ProductService()
    {
        products = new List<Product>();
    }

    //Metod för att lägga till en produkt.
    internal void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Produkten '{product.Name}' har lagts till.");
    }

    //Metod för att visa alla produkter i katalogen.
    internal void ViewProducts()
    {
        if (products.Count == 0) 
        {
            Console.WriteLine($"Det finns inga produkter att visa.");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Produkt: {product.Name},  Pris: {product.Price} kr, Lagersaldo: {product.StockQuantity}");
            }
        }
    }

    internal void RemoveProductByName(string name) //Metod för att ta bort en produkt baserat på namn.
    {
        //Konverterar produktens namn + det angivna namnet till små bokstäver för jämförelse.
        int isFound = products.RemoveAll(product => product.Name?.ToLower() == name.ToLower());

        if (isFound == 0)
        {
            Console.WriteLine($"Det finns inga produkter att ta bort.");
        }
        else
        {
            Console.WriteLine($"Produkt {name} har tagits bort.");
        }
    }

    //Metod för att hämta sparad produkt från fil. 
    public List<Product> GetAllProducts()
    {
        return products;
    }

    //Används vid hämtning av extern produktlista för att lägga till i min lista.
    public void SetProducts(List<Product> loadedProducts)
    {
        products = loadedProducts;
    }
}

