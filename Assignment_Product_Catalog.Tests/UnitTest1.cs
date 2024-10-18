using Assignment_Product_Catalog.Services;
using System.Runtime.CompilerServices;
using Assignment_Product_Catalog.Models;
using System.Diagnostics;

namespace Assignment_Product_Catalog.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddProductToList__Should_AddProductToListOfProducts__Return_ResponseResult_Succeeded()
        {

            //Arrange
            ProductService testProductService = new ProductService(); //Skapar en ny produkt och testar metoden 'AddProduct'.
            var product = new Product
            {
                Name = "Test",
                Description = "Test Description",
                Price = 75,
                StockQuantity = 10
            };

            //Act
            testProductService.AddProduct(product);
            List<Product> products = new List<Product>();
            products = testProductService.GetAllProducts();

            //Assert
            Assert.Contains(product, products); //Kollar om produkten lades till i listan.
            Assert.Single(products); //Kollar att det bara finns 1 produkt i listan.
        }
    }


}