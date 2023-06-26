namespace LookMedico.API.Sales_Payment_Management.Domain.Models;

public class ShoppingCart
{
    public ShoppingCart()
    {
        Orders = new List<Order>();
    }
    
    public int Id { get; set; }

    // Relationships
    
    public List<Order> Orders { get; set; }
}