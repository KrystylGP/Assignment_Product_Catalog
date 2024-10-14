using Assignment_Product_Catalog.Models;
using Assignment_Product_Catalog.Services;

namespace Assignment_Product_Catalog.Menus;
public class MainMenu
{
    internal void RunProgram(ProductService productService, FileService fileService, ProductMenu productMenu) //Kallar på metoden 'RunProgram'.
    {

        Console.WriteLine("Vill du hämta från fil? (Ja/Nej)"); 
        string choice = Console.ReadLine()!.ToLower();

        if (choice == "ja")
        {
            var result = fileService.GetFromFile();
            if (result.Succeeded && result.Result != null)
            {
                var products = fileService.DeserializeProducts(result.Result);
                productService.SetProducts(products); 
                Console.WriteLine("Produkter laddade från fil.");
            }
            else 
            {
                Console.WriteLine("Kunde inte läsa filen: " + result.Message);
            }
        }

        Console.WriteLine($"Välkommen till min produktkatalog!"); 

        bool running = true;

        while (running)
        {   //'Mainmenu'
            Console.WriteLine($"[1] Produkthantering");
            Console.WriteLine($"[2] Spara fil");
            Console.WriteLine($"[3] Avsluta");
            Console.Write("Välj ett alternativ: ");
            string input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    productMenu.ShowProductMenu(productService); //Visar 'ProductMenu'.
                    break;

                case "2":
                    var productList = productService.GetAllProducts(); //Hämtar från fil.
                    
                    var jsonData = fileService.SerializeProducts(productList); //Omvandlar filen till json-format.
                    var saveResult = fileService.SaveToFile(jsonData); //Sparar till filen.

                    if (saveResult.Succeeded)
                    {
                        Console.WriteLine("Produkter har sparats till fil.");
                    }
                    else
                    {
                        Console.WriteLine("Misslyckades med att spara filen: " + saveResult.Message);
                    }
                    break;

                case "3":
                    running = false; //Avslutar programmet.
                    break;

                default:
                    Console.WriteLine("Ogiltig inmatning. Vänligen försök igen.");
                    break;

            }
        }
    }
}
       

       
