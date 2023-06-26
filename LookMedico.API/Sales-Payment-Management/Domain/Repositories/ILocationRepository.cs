using LookMedico.API.Sales_Payment_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Domain.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> ListAsync();
    Task AddAsync(Location location);
    Task<Location> FindByIdAsync(int id);
    void Update(Location location);
    void Remove(Location location);
}