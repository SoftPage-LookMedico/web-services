namespace LookMedico.API.Payment.Domain.Models;

public class E_wallet
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //Relationships
    public int E_walletId { get; set; }
    public int  CardsId { get; set; }
    public Cards Cards { get; set; }
    public List<E_walletTag> E_walletTags { get; set; }
}
