using Assignment_Product_Catalog.Models;
using System.Text.Json;

namespace Assignment_Product_Catalog.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;

    public class ResultResponse<T> //'T': Generic type parameter, kan vara en string eller int.
    {
        public bool Succeeded { get; set; }
        public T? Result { get; set; }
        public string? Message { get; set; }
    }

    public ResultResponse<string> GetFromFile()
    {
        try //Använder mig av try-catch för att fånga upp ev. problem.
        {
            if (!File.Exists(_filePath))
            throw new FileNotFoundException("File not found.");

            using var sr = new StreamReader(_filePath);
            var content = sr.ReadToEnd();

            return new ResultResponse<string> { Succeeded = true, Result = content };
        }
        catch (Exception e)
        {
            return new ResultResponse<string> { Succeeded = false, Message = e.Message };

        }
    }

    public ResultResponse<string> SaveToFile (string content)
    {
        try 
        {
            using var sw = new StreamWriter(_filePath, false);
            sw.WriteLine(content);
            return new ResultResponse<string> { Succeeded = true };
        }
        catch (Exception e) 
        {
            return new ResultResponse<string> { Succeeded = false, Message = e.Message};
        }
    
    }

    public string SerializeProducts(List<Product> products)
    {
        return JsonSerializer.Serialize(products);
    }

    public List<Product> DeserializeProducts(string jsonData)
    {
        return JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
    }

}

       

