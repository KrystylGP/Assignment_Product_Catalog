using Assignment_Product_Catalog.Menus;
using Assignment_Product_Catalog.Services;

public class Program
{
    //Applikationens startpunkt.
    //Huvudmetod (Main) initierar applikationen.

    static void Main(string[] args)
    {
        //Instanser av serviser och menyer.
        FileService fileService = new FileService(@"C:\Users\kryst\OneDrive\Skrivbord\Produktkatalog\products.json"); //Skapar en instans av 'FileService'.
        ProductService productService = new ProductService(); //Skapar en instans av 'ProductService'.
        ProductMenu productMenu = new ProductMenu(); //Skapar en instans av 'ProductMenu'.
        MainMenu menu = new MainMenu(); //Skapar en instans av 'MainMenu'.

        menu.RunProgram(productService, fileService, productMenu);
    }
}
