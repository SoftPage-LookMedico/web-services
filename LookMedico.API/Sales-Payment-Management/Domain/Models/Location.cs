namespace LookMedico.API.Sales_Payment_Management.Domain.Models;

public class Location
{
    public int Id { get; set; }
    
    public string State { get; set; }
    
    public string City { get; set; }

    public string Address { get; set; }
    
    // Relationships

    public int OrderId { get; set; }
    
    public int MedicoId { get; set; }
}




