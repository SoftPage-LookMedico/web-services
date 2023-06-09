using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Context;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.ProfilesManagement.Persistence.Repositories;

public class DoctorRepository:BaseRepository, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await Context.Doctors.ToListAsync();
    }

    public async Task AddAsync(Doctor doctor)
    {
        await Context.Doctors.AddAsync(doctor);
    }

    public async Task<Doctor> FindByIdAsync(string id)
    {
        return await Context.Doctors.FindAsync(id);
    }

    public void Update(Doctor doctor)
    {
        Context.Doctors.Update(doctor);
    }

    public void Remove(Doctor doctor)
    {
        Context.Doctors.Remove(doctor);
    }
}
