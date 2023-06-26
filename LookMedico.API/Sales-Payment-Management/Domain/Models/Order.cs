namespace LookMedico.API.Sales_Payment_Management.Domain.Models;

public class Order
{
    public Order()
    {
        ProductLists = new List<ProductList>();
    }
    
    public int Id { get; set; }
    
    public int MedicoId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string orderDetail { get; set; }
    
    // Relationships
    public List<ProductList> ProductLists { get; set; }
    
    public int ShoppingCartId { get; set; }
    
    public ShoppingCart ShoppingCart { get; set; }
}