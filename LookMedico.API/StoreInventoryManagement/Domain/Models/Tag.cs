namespace LookMedico.API.StoreInventoryManagement.Domain.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    public List<ProductTag> ProductTags { get; set; }
}