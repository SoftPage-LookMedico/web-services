namespace LookMedico.API.Payment.Domain.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //Relationships

    public List<E_walletTag> E_walletTags { get; set; }
}