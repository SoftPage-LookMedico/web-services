namespace LookMedico.API.Store_Inventory_Management.Domain.Models;

public class Category
{
    public Category()
    {
        Products = new List<Product>();
    }

    public int Id { get; set; }
    
    public string Name { get; set;  }
    
    // Relationships
    
    public List<Product> Products { get; set; }
}