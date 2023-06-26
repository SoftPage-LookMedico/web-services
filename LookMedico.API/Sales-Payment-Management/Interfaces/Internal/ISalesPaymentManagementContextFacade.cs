namespace LookMedico.API.Sales_Payment_Management.Interfaces.Internal;

public interface ISalesPaymentManagementContextFacade
{
    int TotalOrders();
    int TotalLocations();
    int TotalShoppingCarts();
    int TotalProductLists();
}