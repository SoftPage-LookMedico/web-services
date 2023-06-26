namespace LookMedico.API.Sales_Payment_Management.Resources;

public class LocationResource
{
    public int Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public OrderResource Order { get; set; }
}