namespace LookMedico.API.Payment.Domain.Models;

public class E_walletTag
{
    //Relationships
    public int E_walletId { get; set; }
    public E_wallet E_wallet { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}