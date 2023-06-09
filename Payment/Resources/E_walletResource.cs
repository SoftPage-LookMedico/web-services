namespace LookMedico.API.Payment.Resources;

public class E_walletResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CardsResource Cards { get; set; }
}