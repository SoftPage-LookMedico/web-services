using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Services.Communication;

namespace LookMedico.API.ProfilesManagement.Domain.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> ListAsync();

    Task<SupplierResponse> SaveAsync(Supplier supplier);

    Task<SupplierResponse> UpdateAsync(string id, Supplier supplier);

    Task<SupplierResponse> DeleteAsync(string id);
}
