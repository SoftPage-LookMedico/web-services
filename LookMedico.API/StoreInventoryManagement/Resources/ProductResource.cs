namespace LookMedico.API.Store_Inventory_Management.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    
    public string Price { get; set; }
    
    public string InventoryStatus { get; set; }
    public CategoryResource Category { get; set; }
}