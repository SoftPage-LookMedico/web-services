using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services;

public interface ILocationService
{
    Task<IEnumerable<Location>> ListAsync();
    Task<LocationResponse> SaveAsync(Location location);
    Task<LocationResponse> UpdateAsync(int locationId, Location location);
    Task<LocationResponse> DeleteAsync(int locationId);
}