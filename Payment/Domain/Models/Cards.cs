namespace LookMedico.API.Payment.Domain.Models;

public class Cards
{
    public Cards()
    {
        E_wallet = new List<E_wallet>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    
    public List<E_wallet>E_wallet { get; set; }
}