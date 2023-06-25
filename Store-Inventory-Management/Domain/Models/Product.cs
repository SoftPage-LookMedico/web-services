namespace LookMedico.API.Store_Inventory_Management.Domain.Models;

public class Product
{
    public int Id { get; set; }

    public int SupplierId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    // Relationships
    
    public int CategoryId { get; set; }

    public Category Category { get; set; }
    
    public List<ProductTag> ProductTags { get; set; }
}
