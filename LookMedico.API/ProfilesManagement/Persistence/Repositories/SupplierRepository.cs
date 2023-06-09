using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Context;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.ProfilesManagement.Persistence.Repositories;

public class SupplierRepository: BaseRepository, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await Context.Suppliers.ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
        await Context.Suppliers.AddAsync(supplier);
    }

    public async Task<Supplier> FindByIdAsync(string id)
    {
        return await Context.Suppliers.FindAsync(id);
    }

    public void Update(Supplier supplier)
    {
        Context.Suppliers.Update(supplier);
    }

    public void Remove(Supplier supplier)
    {
        Context.Suppliers.Remove(supplier);
    }
}
