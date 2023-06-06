using LookMedico.API.ProfilesManagement.Domain.Models;

namespace LookMedico.API.ProfilesManagement.Domain.Repositories;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> ListAsync();

    Task AddAsync(Supplier supplier);

    Task<Supplier> FindByIdAsync(string id);

    void Update(Supplier supplier);

    void Remove(Supplier supplier);
}
