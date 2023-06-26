using LookMedico.API.Store_Inventory_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Domain.Models;

public class ProductList
{
    public ProductList()
    {
        Products = new List<Product>();
    }
    
    public int Id { get; set; }

    // Relationships

    public List<Product> Products { get; set; }
}