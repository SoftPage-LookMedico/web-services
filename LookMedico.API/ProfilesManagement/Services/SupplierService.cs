using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.ProfilesManagement.Domain.Services;
using LookMedico.API.ProfilesManagement.Domain.Services.Communication;
using LookMedico.API.Shared.Domain.Repositories;

namespace LookMedico.API.ProfilesManagement.Services;

public class SupplierService: ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _supplierRepository.ListAsync();
    }
    
    public async Task<Supplier> GetByIdAsync(string id)
    {
        return await _supplierRepository.FindByIdAsync(id);
    }


    public async Task<SupplierResponse> SaveAsync(Supplier supplier)
    {

        var existingSupplier = await _supplierRepository.FindByIdAsync(supplier.Id);

        if (existingSupplier != null)
            return new SupplierResponse("Username is already used.");
        
        try
        {
            await _supplierRepository.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();

            return new SupplierResponse(supplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while saving the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> UpdateAsync(string id, Supplier supplier)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(id);

        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");

        existingSupplier.FirstName = supplier.FirstName;
        existingSupplier.LastName = supplier.LastName;
        existingSupplier.BusinessName = supplier.BusinessName;
        existingSupplier.Address = supplier.Address;
        existingSupplier.Email = supplier.Email;
        existingSupplier.Phone = supplier.Phone;

        try
        {
            _supplierRepository.Update(existingSupplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while updating the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> DeleteAsync(string id)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(id);

        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");

        try
        {
            _supplierRepository.Remove(existingSupplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}
