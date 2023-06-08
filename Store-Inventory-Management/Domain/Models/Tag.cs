namespace LookMedico.API.Store_Inventory_Management.Domain.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    public List<ProductTag> ProductTags { get; set; }
}