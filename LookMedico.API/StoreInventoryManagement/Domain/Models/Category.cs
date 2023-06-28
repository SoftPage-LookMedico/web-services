namespace LookMedico.API.StoreInventoryManagement.Domain.Models;

public class Category
{
    public Category()
    {
        Products = new List<Product>();
    }

    public int Id { get; set; }
    
    public string Name { get; set;  }
    
    public string Description { get; set; }
    
    public string PhotoUrl { get; set; }
    
    // Relationships
    
    public List<Product> Products { get; set; }
}
