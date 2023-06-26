using LookMedico.API.Sales_Payment_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Resources;

public class OrderResource
{
    public int Id { get; set; }
    
    public int MedicoId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string OrderDetail { get; set; }
}