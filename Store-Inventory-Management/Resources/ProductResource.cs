using LookMedico.API.Store_Inventory_Management.Domain.Models;

namespace LookMedico.API.Store_Inventory_Management.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CategoryResource Category { get; set; }
}