namespace LookMedico.API.StoreInventoryManagement.Domain.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Price { get; set; }
    
    public string InventoryStatus { get; set; }
    
    // Relationships
    
    public int CategoryId { get; set; }

    public Category Category { get; set; }
    
    public List<ProductTag> ProductTags { get; set; }
}