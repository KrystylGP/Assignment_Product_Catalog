using Assignment_Product_Catalog.Models;
using Assignment_Product_Catalog.Services;
using Assignment_Product_Catalog.Menus;

namespace Assignment_Product_Catalog.Menus;
public class ProductMenu
{   
    public void ShowProductMenu(ProductService productService)
    {
        bool running = true;

        while (running)
        {   //'ProductMenu'
            Console.WriteLine($"[1] Lägg till produkt");
            Console.WriteLine($"[2] Ta bort produkt");
            Console.WriteLine($"[3] Lista alla produkter");
            Console.WriteLine($"[4] Tillbaka till huvudmenyn");
            Console.Write($"Välj ett alternativ: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddProduct(productService); //Kallar på metoden 'AddProduct' Intern funktion.
                    break;

                case "2":
                    Console.Write("Ange produktnamn: ");
                    string toRemove = Console.ReadLine()!;
                    productService.RemoveProductByName(toRemove); //Kallar på metoden 'RemoveProductByName'.
                   
                    break;

                case "3":
                    productService.ViewProducts(); //Kallar på metoden 'ViewProducts'.
                    break;

                case "4":
                    running = false; //Tillbaka till huvudmenyn.
                    break;
                
                default:
                    Console.WriteLine($"Ogiltig inmatning. Vänligen försök igen.");
                    break;

            }
        }
                
    }

    private void AddProduct(ProductService productService)
    {
        Console.Write("Ange produktnamn: ");
        string? inputName = Console.ReadLine();

        Console.Write("Ange produktbeskrivning: ");
        string? inputDescription = Console.ReadLine();

        Console.Write("Ange produktens pris: ");
        string? inputPrice = Console.ReadLine();
        if (decimal.TryParse(inputPrice, out decimal price)){}
        else
        {
            Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt tal.");
            return; //Returnera om pris är ogiltigt.

        }
        Console.Write("Ange lagersaldo: ");
        string? inputStock = Console.ReadLine();
        if (int.TryParse(inputStock, out int stock)) { }
        else
        {
            Console.WriteLine("Ogiltig inmatning. Vänligen ange ett giltigt tal.");
            return; //Returnera om lagersaldot är ogiltigt.
        }

        //Använder set för att tilldela värden.
        var product = new Product //Kallar konstruktorn för GUID.
        {
            Name = inputName,
            Description = inputDescription,
            Price = price,
            StockQuantity = stock,
        };

        productService.AddProduct(product);
    }
}




